using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _radius = 5f; 
    [SerializeField] private float _baseExplosionForce = 10f;
    [SerializeField] private float _baseExplosionRadiusMultiplier = 2f;

    private const float DISTANCE_SAFETY_MARGIN = 1f;

    public void Explode(Vector3 position, List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rigidbodie in rigidbodies)
        {
            if (rigidbodie != null)
            {
                rigidbodie.AddExplosionForce(_explosionForce, position, _radius);
            }
        }
    }
    public void ExplodeSingleCube(Vector3 position, float cubeScale)
    {
        float explosionRadius = _baseExplosionRadiusMultiplier / cubeScale;
        float baseForce = _baseExplosionForce * (DISTANCE_SAFETY_MARGIN / cubeScale);

        Collider[] hitColliders = Physics.OverlapSphere(position, explosionRadius);

        foreach (Collider collider in hitColliders)
        {
            Rigidbody rigidbodie = collider.GetComponent<Rigidbody>();
            if (rigidbodie != null && rigidbodie != GetComponent<Rigidbody>())
            {
                Vector3 direction = collider.transform.position - position;
                float distance = direction.magnitude;
                float force = baseForce * (DISTANCE_SAFETY_MARGIN / (distance + DISTANCE_SAFETY_MARGIN));

                rigidbodie.AddForce(direction.normalized * force, ForceMode.Impulse);
            }
        }
    }
}