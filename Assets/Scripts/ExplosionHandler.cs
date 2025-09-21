using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _radius = 5f;

    public void Explode(Vector3 position, List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb != null)
            {
                rb.AddExplosionForce(_explosionForce, position, _radius);
            }
        }
    }
}