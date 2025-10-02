using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _chanceMultiplier = 0.5f;
    [SerializeField] private int minCount = 2;
    [SerializeField] private int maxCount = 6;
    [SerializeField] private Cube _cube;
    [SerializeField] private CubeHitEventManager _cubeHitEventManager;

    [SerializeField] public float ScaleMultiplier { get; private set; } = 0.5f;

    private void OnEnable()
    {
        _cubeHitEventManager.CubeSpawned += SpawnFromCube;
    }

    private void OnDisable()
    {
        _cubeHitEventManager.CubeSpawned -= SpawnFromCube;
    }

    private void SpawnFromCube(Cube sourceCube)
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