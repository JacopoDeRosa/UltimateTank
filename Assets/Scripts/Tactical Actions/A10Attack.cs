using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A10Attack : MonoBehaviour
{
    [SerializeField] private float _damage;

    public void OnParticleHit(ParticleCollisionEvent hit)
    {
        var hitbox = hit.colliderComponent.GetComponent<HitboxPiece>();
        if(hitbox)
        {
            hitbox.Hit(_damage);
        }
    }
}
