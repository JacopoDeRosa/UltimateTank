using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TankAITurret : MonoBehaviour
{
    [SerializeField] private Transform  _turretPointer, _cannonPointer;
    [SerializeField] private Transform _target;
    [SerializeField] private float _minElevation, _maxElevation;

    private void Awake()
    {
        if (_target == null) _target = FindObjectOfType<PlayerTankMover>().transform;
        if (_target == null) Destroy(this);
    }

    private void Update()
    {
        RotateTurret();
        RotateCannon();
    }

    private void RotateTurret()
    {
        Vector3 localAimPoint = transform.InverseTransformPoint(_target.position);
        localAimPoint.y = 0;
        Quaternion look = Quaternion.LookRotation(localAimPoint);
        _turretPointer.localRotation = look;
    }

    private void RotateCannon()
    {
        Vector3 localAimPoint = _turretPointer.InverseTransformPoint(_target.position);
        localAimPoint.y = Mathf.Clamp(localAimPoint.y, _minElevation, _maxElevation);

        Quaternion look = Quaternion.LookRotation(localAimPoint - _cannonPointer.localPosition);
        _cannonPointer.localRotation = look;
    }
}
