using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankTurretController : MonoBehaviour
{
    [SerializeField] private Transform _turretPointer, _cannonPointer;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private bool _invertMouseY;
    [SerializeField]
    private Vector2 _mouseInput;

    private void Awake()
    {
        if (_input)
        {
            _input.actions["Look"].performed += OnLook;
        }
    }

    private void OnDestroy()
    {
        if (_input)
        {
            _input.actions["Look"].performed -= OnLook;
        }
    }
    private void OnLook(InputAction.CallbackContext context)
    {
        _mouseInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        _turretPointer.Rotate(new Vector3(0, _mouseInput.x * _rotSpeed * Time.deltaTime, 0));
        if (_invertMouseY)
        {
            _cannonPointer.Rotate(new Vector3(_mouseInput.y * _rotSpeed * -1 * Time.deltaTime, 0, 0));
        }
        else
        {
            _cannonPointer.Rotate(new Vector3(_mouseInput.y * _rotSpeed * Time.deltaTime, 0, 0));
        }
    }
}
