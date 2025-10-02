using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    public float ScaleMultiplier { get; set; } = 0.5f;
    public int Generation { get; private set; } = 0;
    public float SpawnChance { get; private set; } = 1f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetRandomColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void ChangeChance(float chanceMultiply)
    {
        SpawnChance *= chanceMultiply;
    }

    public void IncreaseGeneration()
    {
        Generation++;
    }
}