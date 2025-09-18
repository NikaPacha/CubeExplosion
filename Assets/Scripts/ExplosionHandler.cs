using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _radius = 5f;

    public void Explode(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, _radius);

        foreach (Collider collider in hitColliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_explosionForce, position, _radius);
            }
        }
    }
}