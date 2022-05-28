using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Vector3 _recoil;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _cannonMuzzle;
    [SerializeField] private ParticleSystem _cannonShotParticle;
    [SerializeField] private MachineGun _coaxMachineGun;
    [SerializeField] private PlayerInput _input;


    private void Awake()
    {
        if(_input)
        {
            _input.actions["Fire"].started += OnFire;
            _input.actions["Fire 2"].started += OnFire2Down;
            _input.actions["Fire 2"].canceled += OnFire2Up;
        }
    }

    private void OnDestroy()
    {
        if (_input)
        {
            _input.actions["Fire"].started -= OnFire;
            _input.actions["Fire 2"].started -= OnFire2Down;
            _input.actions["Fire 2"].canceled -= OnFire2Up;
        }
    }


    private void OnFire(InputAction.CallbackContext context)
    {
        if (GameStatus.controlsLocked) return;

        _rigidbody.AddForceAtPosition(_cannonMuzzle.TransformDirection(_recoil), _cannonMuzzle.position, ForceMode.Impulse);
        _cannonShotParticle.Play();
        print("Pew");
    }

    private void OnFire2Down(InputAction.CallbackContext context)
    {
        _coaxMachineGun.ToggleFire(true);
    }
    private void OnFire2Up(InputAction.CallbackContext context)
    {
        _coaxMachineGun.ToggleFire(false);
    }
}
