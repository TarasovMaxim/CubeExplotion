using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explodeRadius = 5f;
    [SerializeField] private float _explodeForce = 500f;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private Raycaster _raycaster;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cube cube = _raycaster.FindCube();

            if (cube != null)
            {
                Explode(cube.gameObject.transform.localPosition);
                _spawner.SpawnFromCube(cube);
                Destroy(cube.gameObject);
            }
        }
    }

    private void Explode(Vector3 position)
    {
        if (_effect != null)
        {
            ParticleSystem effect = Instantiate(_effect, position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, 0.5f);
        }

        Collider[] hits = Physics.OverlapSphere(position, _explodeRadius);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(_explodeForce, position, _explodeRadius);
            }
        }
    }
}