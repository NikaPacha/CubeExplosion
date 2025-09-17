using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public event Action<Cube, List<Rigidbody> > NewCubesSpawned;

    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _minCubesToSpawn = 2;
    [SerializeField] private int _maxCubesToSpawn = 6;
    [SerializeField] private float _differenceScaleCubes = 2;

    private void Start()
    {
        if (_cubePrefab == null)
        {
            Debug.LogError("Префаб не установлен!");
            return;
        }
    }

    public void CreateNewCubes(Cube cube, float splitChance)
    {
        int numberCubes = Random.Range(_minCubesToSpawn, _maxCubesToSpawn);
        List<Rigidbody> cubes = new List<Rigidbody>();

        for (int i = 1; i <= numberCubes; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, cube.transform.position, Quaternion.identity);
            newCube.InitializeSplitChance(splitChance);
            newCube.transform.localScale = cube.transform.localScale / _differenceScaleCubes;
            newCube.spawner = this;

            if (newCube.TryGetComponent(out Rigidbody cubeRigidbody))
            {
                cubes.Add(cubeRigidbody);
            }
        }

        NewCubesSpawned?.Invoke(cube, cubes);
    }
}