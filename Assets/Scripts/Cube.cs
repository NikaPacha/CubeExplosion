using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> OnCubeClicked;

    public float SplitChance = 100f;
    public Spawner spawner;
    public Renderer renderer;
    public Rigidbody rigidbody;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        OnCubeClicked?.Invoke(this);
    }

    public void InitializeSplitChance(float chance)
    {
        SplitChance = chance;
    }
}
