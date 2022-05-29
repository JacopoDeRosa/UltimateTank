using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

