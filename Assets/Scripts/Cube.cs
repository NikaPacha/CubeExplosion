using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 100f;
    public Spawner _spawner;
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void InitializeSplitChance(float chance)
    {
        _splitChance = chance;
    }

    public Spawner Spawner
    {
        get => _spawner;
        set => _spawner = value;
    }

    public float SplitChance
    {
        get => _splitChance;
        set => _splitChance = value;
    }
}
