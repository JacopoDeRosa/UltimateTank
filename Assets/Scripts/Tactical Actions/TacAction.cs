using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacAction : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private TacActionsManager _manager;

    protected virtual void OnValidate()
    {
        if(_manager == null)
        {
            _manager = FindObjectOfType<TacActionsManager>();
        }
    }

    public virtual void Begin()
    {
        
    }

    public virtual void End()
    {

    }
}
