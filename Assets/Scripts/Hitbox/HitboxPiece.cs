using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HitboxPiece : MonoBehaviour
{
    public event Action<float> onDamage;

    public void Hit(float damage)
    {
        onDamage.Invoke(damage);
    }
}
