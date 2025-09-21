using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ExplosionHandler _explosionHandler;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private InputHandler _inputHandler;

    private int _reducingChanceDivision = 2;
    private int _minChanceDivision = 0;
    private int _maxChanceDivision = 100;

    private void Start()
    {
        _inputHandler.OnMouseClicked += HandleMouseClick;
        _raycaster.CubeHit += HandleCubeHit;
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