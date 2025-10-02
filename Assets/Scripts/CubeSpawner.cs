using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _chanceMultiplier = 0.5f;
    [SerializeField] private int minCount = 2;
    [SerializeField] private int maxCount = 6;
    [SerializeField] private Raycaster _raycaster;

    [SerializeField] public float ScaleMultiplier { get; private set; } = 0.5f;

    private void OnEnable()
    {
        _raycaster.CubeFounded += SpawnFromCube;
    }

    private void OnDisable()
    {
        _raycaster.CubeFounded -= SpawnFromCube;
    }

    private void SpawnFromCube(Cube sourceCube)
    {
        if (CanSpawn(sourceCube))
        {
            for (int i = 0; i < Random.Range(minCount, maxCount); i++)
            {
                Cube clone = Instantiate(sourceCube);
                clone.IncreaseGeneration();
                clone.transform.localScale *= ScaleMultiplier;
                clone.SetRandomColor();
                clone.ChangeChance(_chanceMultiplier);
            }
        }
    }

    private bool CanSpawn(Cube cube)
    {
        return Random.value < cube.SpawnChance;
    }
}