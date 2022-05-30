using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private List<HitboxPiece> _pieces;

    private void Awake()
    {
        foreach (var piece in _pieces)
        {
            piece.onDamage += OnPieceHit;
        }
    }

    private void OnPieceHit(float damage)
    {
        _health.DealDamage(damage);
    }
}
