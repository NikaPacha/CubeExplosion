using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ExplosionHandler _explosionHandler;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private InputHandler _inputHandler;

    private int _reducingChanceDivision = 2;
    private int _minChanceDivision = 0;
    private int _maxChanceDivision = 100;

    public Spawner Spawner
    {
        get => _spawner;
        set => _spawner = value;
    }

    public event Action OnGameStarted;

    private void OnEnable()
    {
        if (_inputHandler != null)
            _inputHandler.OnMouseClicked += HandleMouseClick;

        if (_raycaster != null)
            _raycaster.CubeHit += HandleCubeHit;
    }

    private void OnDisable()
    {
        if (_inputHandler != null)
            _inputHandler.OnMouseClicked -= HandleMouseClick;

        if (_raycaster != null)
            _raycaster.CubeHit -= HandleCubeHit;
    }

    private void Start()
    {
        OnGameStarted?.Invoke();
    }

    private void HandleMouseClick()
    {
        _raycaster.PerformRaycast();
    }

    private void HandleCubeHit(Cube cube)
    {
        if (Random.Range(_minChanceDivision, _maxChanceDivision) <= cube.SplitChance)
        {
            List<Rigidbody> spawnedCubes = _spawner.CreateNewCubes(cube, cube.SplitChance / _reducingChanceDivision);
            _explosionHandler.Explode(cube.transform.position, spawnedCubes);
        }
        Destroy(cube.gameObject);
    }
}
