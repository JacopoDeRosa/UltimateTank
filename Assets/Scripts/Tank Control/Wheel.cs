using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
