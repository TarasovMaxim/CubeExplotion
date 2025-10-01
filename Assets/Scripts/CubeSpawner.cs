using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _chanceMultiplier = 0.5f;
    [SerializeField] private float _scaleMultiplier = 0.5f;
    [SerializeField] private int minCount = 2;
    [SerializeField] private int maxCount = 6;

    public void SpawnFromCube(Cube sourceCube)
    {
        if (CanSpawn(sourceCube))
        {

            for (int i = 0; i < Random.Range(minCount, maxCount); i++)
            {
                Cube clone = Instantiate(sourceCube);
                clone.transform.localScale *= _scaleMultiplier;
                clone.GetComponent<Cube>()?.SetRandomColor();
                clone.ChangeChance(_chanceMultiplier);
            }
        }
    }

    private bool CanSpawn(Cube cube)
    {
        return Random.value < cube.SpawnChance;
    }
}