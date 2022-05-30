using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAIShooter : MonoBehaviour
{
    [SerializeField] private Vector3 _recoil;
    [SerializeField] private float _range;
    [SerializeField] private float _damage;
    [SerializeField] private Cannon _cannon;
    [SerializeField] private Rigidbody _rigidbody;


    private void Update()
    {
        if(Physics.Raycast(_cannon.transform.position, _cannon.transform.forward, out RaycastHit hit, _range))
        {
            if(hit.collider.tag == "Player")
            {
                if(_cannon.Fire())
                {
                    _rigidbody.AddForceAtPosition(_cannon.transform.TransformDirection(_recoil), _cannon.transform.position, ForceMode.Impulse);
                }
            }
        }
    }

    public void OnCannonHit(ParticleCollisionEvent particleCollisionEvent)
    {
        var hitbox = particleCollisionEvent.colliderComponent.gameObject.GetComponent<HitboxPiece>();
        if(hitbox != null)
        {
            hitbox.Hit(_damage);
        }
    }

}
