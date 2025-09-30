using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void SetRandomColor()
    {
        GetComponent<Renderer>().material.color= new Color(Random.value, Random.value, Random.value);
    }
}
