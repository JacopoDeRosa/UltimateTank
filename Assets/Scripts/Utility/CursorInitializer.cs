using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInitializer : MonoBehaviour
{

    [SerializeField] private CursorLockMode _startLockmode;

    private void Start()
    {
        Cursor.lockState = _startLockmode;
    }

}
