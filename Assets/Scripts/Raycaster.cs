using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public Cube FindCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Cube cube;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.collider.GetComponent<Cube>();

        }

        return null;
    }
}