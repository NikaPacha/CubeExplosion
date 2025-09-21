using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private int _mouseButton = 0;

    public event Action OnMouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            OnMouseClicked?.Invoke();
        }
    }
}