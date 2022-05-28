using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacActionsManager : MonoBehaviour
{
    private TacAction _activeAction;

    public bool Busy { get => _activeAction != null; }

    
}
