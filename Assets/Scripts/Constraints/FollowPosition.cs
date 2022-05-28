using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool _slowFollow;
    [SerializeField] private float _followSpeed;

    private float _actFollowSpeed;

    private void LateUpdate()
    {
        if (_target.hasChanged)
        {
            if (_slowFollow)
            {
                _actFollowSpeed = Mathf.Clamp01(_followSpeed * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, _target.position, _actFollowSpeed);
            }
            else
            {
                transform.position = _target.position;
            }
        }
    }
}
