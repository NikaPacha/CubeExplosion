using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public LayerMask cubeLayer;
    private int _mouseButton = 0;

    public event Action<Cube> CubeHit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, cubeLayer))
            {
                if (hit.transform.TryGetComponent(out Cube cube))
                {
                    CubeHit?.Invoke(cube);
                }
            }
        }
    }
}