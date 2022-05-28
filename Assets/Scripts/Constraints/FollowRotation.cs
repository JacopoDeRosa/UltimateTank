using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool _slowFollow;
    [SerializeField] private float _followSpeed;
    [SerializeField] private TransformSpace _space = TransformSpace.Local;

    private float _actFollowSpeed;

    void Update()
    {
        if (_target.hasChanged)
        {
            if (_space == TransformSpace.Local)
            {
                if (_slowFollow)
                {
                    _actFollowSpeed = Mathf.Clamp01(_followSpeed * Time.deltaTime);
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, _target.localRotation, _actFollowSpeed);
                }
                else
                {
                    transform.localRotation = _target.localRotation;
                }
            }
            else if(_space == TransformSpace.World)
            {
                if (_slowFollow)
                {
                    _actFollowSpeed = Mathf.Clamp01(_followSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, _actFollowSpeed);
                }
                else
                {
                    transform.rotation = _target.rotation;
                }
            }
        }
    }
}
