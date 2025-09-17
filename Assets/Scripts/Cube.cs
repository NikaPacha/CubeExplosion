using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosianRadius = 5;
    [SerializeField] private float _explosianForse = 500;
    [SerializeField] private float _reducingSplitChance = 2;

    private float _maxSplitChance = 100f;
    private float _minSplitChance = 0f;

    public float SplitChance { get; private set; } = 100f;
    public Renderer ChoiceCubeColor { get; private set; }
    public Rigidbody CubePhysicsComponent { get; private set; }

    public Spawner spawner;

    private void Awake()
    {
        ChoiceCubeColor = GetComponent<Renderer>();
        CubePhysicsComponent = GetComponent<Rigidbody>();
    }

    private void OnMouseUpAsButton()
    {
        if (Random.Range(_minSplitChance, _maxSplitChance) <= SplitChance)
        {
            spawner.CreateNewCubes(this, SplitChance);
        }
        Destroy(gameObject);
        Explode();
    }
    public void InitializeSplitChance(float chanceDivide)
    {
        SplitChance = chanceDivide / _reducingSplitChance;
    }

    public void Explode()
    {
        foreach (Rigidbody exploadableObject in GetExploadableObjects())
            exploadableObject.AddExplosionForce(_explosianForse, transform.position, _explosianRadius);
    }

    private List<Rigidbody> GetExploadableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosianRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;

    }
}