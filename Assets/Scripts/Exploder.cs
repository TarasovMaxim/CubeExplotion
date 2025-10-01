using UnityEngine;
using System;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explodeRadius = 5f;
    [SerializeField] private float _explodeForce = 500f;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Raycaster _raycaster;

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

    private void Explode(Cube cube)
    {
        if (_effect != null)
        {
            ParticleSystem effect = Instantiate(_effect, cube.transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, 0.5f);
        }

        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explodeRadius);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(_explodeForce, cube.transform.position, _explodeRadius);
            }
        }
    }
}