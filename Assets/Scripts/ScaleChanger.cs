using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private float _scaler = 0.5f;

    private void OnEnable()
    {
        gameObject.GetComponent<CubeSpawner>().TapCube += DecreaseScale;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<CubeSpawner>().TapCube -= DecreaseScale;
    }

    private void DecreaseScale()
    {
        gameObject.transform.localScale *= _scaler;
    }
}
