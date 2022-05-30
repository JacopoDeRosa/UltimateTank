using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _totalHp;

    private bool _dead;

    public UnityEvent<float> onDamageTaken;
    public UnityEvent onDeath;

    public void DealDamage(float damage)
    {
        if (_dead) return;

        _totalHp -= damage;
        onDamageTaken.Invoke(damage);

        if(_totalHp <= 0)
        {
            _totalHp = 0;
            onDeath.Invoke();
            _dead = true;

            OnDeath();
        }    
    }

    protected virtual void OnDeath()
    {

    }
}
