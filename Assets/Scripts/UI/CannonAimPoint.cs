using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonAimPoint : MonoBehaviour
{
    [SerializeField] private Graphic _trueAimPoint, _wantedAimPoint;
    [SerializeField] private Transform _cannon, _cannonPointer;
    [SerializeField] private float _zeroPoint;


    private void Update()
    {
        _trueAimPoint.transform.position = Camera.main.WorldToScreenPoint(_cannon.forward * _zeroPoint);
        _wantedAimPoint.transform.position = Camera.main.WorldToScreenPoint(_cannonPointer.forward * _zeroPoint);
    }
}
