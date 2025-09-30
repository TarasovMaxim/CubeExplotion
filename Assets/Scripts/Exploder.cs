using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;
    [SerializeField] private ParticleSystem _effect;

    private void OnEnable()
    {
        gameObject.GetComponent<CubeSpawner>().TapCube += Explode;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<CubeSpawner>().TapCube -= Explode;
    }

    private void Explode()
    {
        float timeExplode = 0.5f;

        if (_effect != null)
        {
            ParticleSystem effectInstance = Instantiate(_effect, transform.position, Quaternion.identity);
            effectInstance.Play();
            Destroy(effectInstance.gameObject, timeExplode);
        }

        foreach (Rigidbody cube in GetExplodableObjects())
        {
            cube.AddExplosionForce(_explodeForce, transform.position, _explodeRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explodeRadius);
        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }
}
