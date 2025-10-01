using UnityEngine;

public class Cube : MonoBehaviour
{
    public float SpawnChance { get; private set; } = 1f;

    public void SetRandomColor()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void ChangeChance(float chanceMultiply)
    {
        SpawnChance *= chanceMultiply;
    }
}