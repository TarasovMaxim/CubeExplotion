using UnityEngine;
using System;

public class Raycaster : MonoBehaviour
{
    public event Action<Cube> CubeFounded;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindCube();
        }
    }

    private void FindCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            CubeFounded?.Invoke(hit.collider.GetComponent<Cube>());
        }
    }
}