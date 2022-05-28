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

[System.Serializable]
public class TankTrack
{
    [SerializeField]
    private Wheel[] _wheels;


    private bool _break;

    public void SetTorque(float torque)
    {
        foreach (Wheel wheel in _wheels)
        {
            wheel.Collider.motorTorque = torque;
        }
    }
    public void SetBrake(float torque)
    {
        foreach (Wheel wheel in _wheels)
        {
            wheel.Collider.brakeTorque = torque;
        }
    }
    public void UpdateTransforms()
    {
        foreach (Wheel wheel in _wheels)
        {
            wheel.UpdateTransform();
        }
    }
}


[System.Serializable]
public class Wheel
{
    [SerializeField] private WheelCollider _collider;
    [SerializeField] private Transform _wheel;

    public WheelCollider Collider { get => _collider; }

    public void UpdateTransform()
    {
        _collider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        _wheel.position = pos;
        _wheel.rotation = rot;
    }
}

