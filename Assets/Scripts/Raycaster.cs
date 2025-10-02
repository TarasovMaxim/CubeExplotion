using UnityEngine;
using System;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Inputer _inputer;
    public event Action<Cube> CubeFounded;

    private void OnEnable()
    {
        _inputer.OnInput += FindCube;
    }

    private void OnDisable()
    {
        _inputer.OnInput -= FindCube;
    }

    private void FindCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        hit.collider.TryGetComponent(out Cube cube);
        CubeFounded?.Invoke(cube);
    }
}