using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonAimPoint : MonoBehaviour
{
    [SerializeField] private Graphic _trueAimPoint;
    [SerializeField] private Transform _cannon;
    [SerializeField] private float _zeroPoint;


  
    private void Update()
    {
        Ray ray = new Ray(_cannon.position, _cannon.forward);
        Vector3 pos = ray.GetPoint(_zeroPoint);
        _trueAimPoint.transform.position = Camera.main.WorldToScreenPoint(pos);
    }
}
