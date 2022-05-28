using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStickToGround : MonoBehaviour
{
    [SerializeField] private LayerMask _terrainMask;
    [SerializeField] private Transform _rotationTransform;

    private void Update()
    {
        Debug.DrawRay(transform.position, -transform.up);
        if(Physics.Raycast(transform.position + Vector3.up, transform.position + Vector3.down, out RaycastHit hit, Mathf.Infinity, _terrainMask))
        {
            _rotationTransform.localRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
    }
}
