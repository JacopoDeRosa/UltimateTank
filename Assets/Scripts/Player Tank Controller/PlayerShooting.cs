using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Vector3 _recoil;
    [SerializeField] private float _damage;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Cannon _cannon;
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

       
        if(_cannon.Fire())
        {
            _rigidbody.AddForceAtPosition(_cannon.transform.TransformDirection(_recoil), _cannon.transform.position, ForceMode.Impulse);
        }
      
    }

    private void OnFire2Down(InputAction.CallbackContext context)
    {
        _coaxMachineGun.ToggleFire(true);
    }
    private void OnFire2Up(InputAction.CallbackContext context)
    {
        _coaxMachineGun.ToggleFire(false);
    }

    public void OnCannonHit(ParticleCollisionEvent collisionEvent)
    {
        var hitbox = collisionEvent.colliderComponent.gameObject.GetComponent<HitboxPiece>();
        if (hitbox != null)
        {
            hitbox.Hit(_damage);
        }
    }
}
