using System;
using UnityEngine;

public class CubeHitEventManager : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    public event Action<Cube> CubeSpawned;
    public event Action<Cube> CubeExplode;

    private void OnEnable()
    {
        _raycaster.CubeFounded += SelectEvent;
    }

    private void OnDisable()
    {
        _raycaster.CubeFounded += SelectEvent;
    }

    private void SelectEvent(Cube cube)
    {
        if (UnityEngine.Random.value < cube.SpawnChance)
        {
            CubeSpawned?.Invoke(cube);
            CubeExplode?.Invoke(cube);
        }
        else
            CubeExplode?.Invoke(cube);
    }
}
