using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCannonShooting : MonoBehaviour
{
    [SerializeField] private Vector3 _recoil;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private PlayerInput _input;


    private void Awake()
    {
        if(_input)
        {
            _input.actions["Fire"].started += OnFire;
        }
    }

    private void OnDestroy()
    {
        if (_input)
        {
            _input.actions["Fire"].started -= OnFire;
        }
    }


    private void OnFire(InputAction.CallbackContext context)
    {
        _rigidbody.AddForceAtPosition(_muzzle.TransformDirection(_recoil), _muzzle.position, ForceMode.Impulse);
        print("Pew");
    }
}
