using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private float _splitChance = 100f;
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public float SplitChance
    {
        get => _splitChance;
        set => _splitChance = value;
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void InitializeSplitChance(float chance)
    {
        _splitChance = chance;
    }
}