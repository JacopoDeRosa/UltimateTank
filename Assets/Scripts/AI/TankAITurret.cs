using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAITurret : MonoBehaviour
{
    [SerializeField] private Transform  _turretPointer, _cannonPointer;
    [SerializeField] private Transform _target;
    [SerializeField] private float _minElevation, _maxElevation;


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
        Vector3 localAimPoint = transform.InverseTransformPoint(_target.position);
        localAimPoint.x = 0;
        localAimPoint.z = 0;


        Quaternion look = Quaternion.LookRotation(localAimPoint);
        _cannonPointer.localRotation = look;
    }
}
