using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TacCamController : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;


    private void OnEnable()
    {
        if (_input == null)
        {
            _input = FindObjectOfType<PlayerInput>();
        }
        if (_input)
        {
            _input.actions["Scroll"].performed += OnScroll;
        }
    }

    private void OnDisable()
    {
        if (_input)
        {
            _input.actions["Scroll"].performed -= OnScroll;
        }
    }

    private void OnScroll(InputAction.CallbackContext context)
    {
        print(context.ReadValue<float>());
    }
}
