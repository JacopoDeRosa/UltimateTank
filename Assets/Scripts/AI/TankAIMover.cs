using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAIMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private TankTrack _leftTrack;
    [SerializeField] private TankTrack _rightTrack;
    [SerializeField] private float _motorTorque;
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private float _minimumSafeDistance;
    [SerializeField] private float _turningCoefficent;
    [SerializeField] private float _breakCoefficent;

    private float _targetAngle;
    private bool _destinationReached;
    private bool _unsafeDistance;
    private float _distanceFromTarget;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.rotation * Vector3.forward, 0.5f);
    }
    private void Update()
    {
        CalculateDistanceFromTarget();
        CalculateTargetAngle();
        CalculateDestinationReached();
        CalculateUnsafeDistance();
        SetTracksTorque();
    }

    private void CalculateTargetAngle()
    {
        Vector3 flatPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 flatTargetPos = new Vector3(_target.position.x, 0, _target.position.z);
        Vector3 flatForward = new Vector3(transform.forward.x, 0, transform.forward.z);
        _targetAngle = Vector3.SignedAngle((flatPosition + flatForward) - flatPosition, flatTargetPos - flatPosition, Vector3.up);
    }

    private void CalculateDestinationReached()
    {
        _destinationReached = _distanceFromTarget < _stoppingDistance;
    }

    private void CalculateUnsafeDistance()
    {
        _unsafeDistance = _distanceFromTarget < _minimumSafeDistance;
    }

    private void CalculateDistanceFromTarget()
    {
        _distanceFromTarget = Vector3.Distance(transform.position, _target.position);
    }

    private void SetTracksTorque()
    {
        float leftTrackInput = 1;
        float rightTrackInput = 1;

        if (_unsafeDistance)
        {
            leftTrackInput = 0;
            rightTrackInput = 0;
            _leftTrack.SetBrake(_motorTorque * _breakCoefficent);
            _rightTrack.SetBrake(_motorTorque * _breakCoefficent);
        }
        else
        {
            _leftTrack.SetBrake(0);
            _rightTrack.SetBrake(0);
        }

        if (_targetAngle > 0)
        {
            rightTrackInput -= (_targetAngle / 180) * _turningCoefficent;
        }
        else if (_targetAngle < 0)
        {
            leftTrackInput -= ((_targetAngle * -1) / 180) * _turningCoefficent;
        }

        if (_destinationReached)
        {
            if (_targetAngle > 0)
            {
                rightTrackInput *= -1;
            }
            else if (_targetAngle < 0)
            {
                leftTrackInput *= -1;
            }
        }

        _leftTrack.SetTorque(_motorTorque * leftTrackInput);
        _rightTrack.SetTorque(_motorTorque * rightTrackInput);

        _leftTrack.UpdateTransforms();
        _rightTrack.UpdateTransforms();
    }
}
