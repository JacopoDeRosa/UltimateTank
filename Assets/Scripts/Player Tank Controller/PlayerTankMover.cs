using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTankMover : MonoBehaviour
{
    [SerializeField] private TankTrack _leftTrack, _rightTrack;
    [SerializeField] private float _motorTorque;
    [SerializeField] private PlayerInput _input;

    [SerializeField]
    private Vector2 _moveInput;

    private void Awake()
    {
        if (_input)
        {
            _input.actions["Move"].performed += OnMove;
        }
    }
    private void OnDestroy()
    {
        if (_input)
        {
            _input.actions["Move"].performed -= OnMove;
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        float rightTrackInput = Mathf.Clamp(_moveInput.y + (_moveInput.x * -1), -1, 1);
        float leftTrackInput = Mathf.Clamp(_moveInput.y + _moveInput.x, -1, 1);

        if (GameStatus.controlsLocked)
        {
            rightTrackInput = 0;
            leftTrackInput = 0;
        }
       

        _leftTrack.SetTorque(leftTrackInput * _motorTorque);
        _rightTrack.SetTorque(rightTrackInput * _motorTorque);

        _leftTrack.UpdateTransforms();
        _rightTrack.UpdateTransforms();
    }
}


