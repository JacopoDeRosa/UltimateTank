using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTurretController : MonoBehaviour
{
    [SerializeField] private Transform _turretPointer, _cannonPointer;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private float _maxElevation, _minElevation;


    [SerializeField]
    private Vector2 _mouseInput;

    [SerializeField]
    private float _currentElevation;

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
        if (GameStatus.controlsLocked) return;
        RotateTurret();
        RotateCannon();
    }

    private void RotateCannon()
    {
        float change = _mouseInput.y * _rotSpeed * -1 * Time.deltaTime; 

        if (_currentElevation >= _minElevation && _mouseInput.y < 0)
        {
            return;
        }
        else if(_currentElevation <= _maxElevation && _mouseInput.y > 0)
        {
            return;
        }
        _currentElevation += change;
        _cannonPointer.Rotate(new Vector3(change, 0, 0));     
    }

    private void RotateTurret()
    {
        _turretPointer.Rotate(new Vector3(0, _mouseInput.x * _rotSpeed * Time.deltaTime, 0));
    }
}
