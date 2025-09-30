using System;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private int minCount = 2;
    private int maxCount = 6;
    private float _spawnerChance = 1f;
    private float _miltiplySpawnerChance = 0.5f;
    public event Action TapCube;

    private void OnMouseDown()
    {
        TapCube?.Invoke();

        if (CanSpawn())
        {
           
            for (int i = 0; i < UnityEngine.Random.Range(minCount, maxCount); i++)
            {
                Spawn();
            }
        }

        Destroy(gameObject);
    }

    private void Spawn()
    {
        GameObject clone = Instantiate(gameObject);
        clone.SendMessage("SetRandomColor");
        clone.GetComponent<CubeSpawner>()._spawnerChance = _spawnerChance;
        clone.GetComponent<CubeSpawner>().DecreaseChance();
    }

    private void DecreaseChance()
    {
        _spawnerChance *= _miltiplySpawnerChance;
    }

    private bool CanSpawn()
    {
        return UnityEngine.Random.value < _spawnerChance;
    }
}
