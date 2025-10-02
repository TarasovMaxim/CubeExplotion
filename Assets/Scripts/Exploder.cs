using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _startExplodeRadius = 5f;
    [SerializeField] private float _startExplodeForce = 500f;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeSpawner _cubeSpawner;

    private void OnDisable()
    {
        _raycaster.CubeFounded -= Explode;
        _raycaster.CubeFounded -= DestroyCube;
    }

    private void OnEnable()
    {
        _raycaster.CubeFounded += Explode;
        _raycaster.CubeFounded += DestroyCube;
    }

    private void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    private float ÑalculateCurrentValue(float start, float multiply, float degree)
    {
        return start / Mathf.Pow(multiply, degree);
    }

    private void Explode(Cube cube)
    {
        float explodeForce = ÑalculateCurrentValue(_startExplodeForce, _cubeSpawner.ScaleMultiplier, cube.Generation);
        float explodeRadius= ÑalculateCurrentValue(_startExplodeRadius, _cubeSpawner.ScaleMultiplier, cube.Generation);

        if (_effect != null)
        {
            ParticleSystem effect = Instantiate(_effect, cube.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, 0.5f);
        }

        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _startExplodeRadius);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(explodeForce, cube.transform.position, explodeRadius);
            }
        }
    }
}