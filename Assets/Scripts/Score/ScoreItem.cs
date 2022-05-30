using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{

    [SerializeField] private int _value;

    public void Register()
    {
        var sk = FindObjectOfType<ScoreKeeper>();
        if(sk)
        {
            sk.AddScore(_value);
        }

    }
}
