using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private LayerMask _cubeLayer;

    public event Action<Cube> CubeHit;

    public void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _cubeLayer))
        {
            if (hit.transform.TryGetComponent(out Cube cube))
            {
                CubeHit?.Invoke(cube);
            }
        }
    }
}