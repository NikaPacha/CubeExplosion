using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ExplosionHandler _explosionHandler;
    private int _reducingChanceDivision = 2;

    private void Start()
    {
        // Подписываемся на событие от Raycaster
        Raycaster raycaster = FindObjectOfType<Raycaster>();
        if (raycaster != null)
            raycaster.CubeHit += HandleCubeHit;
    }

    private void HandleCubeHit(Cube cube)
    {
        // Проверяем вероятность деления
        if (Random.Range(0f, 100f) <= cube.SplitChance)
        {
            // Создаем новые кубы
            _spawner.CreateNewCubes(cube, cube.SplitChance / _reducingChanceDivision);

            // Запускаем взрыв
            _explosionHandler.Explode(cube.transform.position);

            Destroy(cube.gameObject);
        }
            Destroy(cube.gameObject);
    }
}