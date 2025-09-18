using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public event Action<Cube> CubeHit;
    public LayerMask cubeLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, cubeLayer))
            {
                Cube cube = hit.transform.GetComponent<Cube>();
                if (cube != null)
                {
                    CubeHit?.Invoke(cube);
                }
            }
        }
    }
}