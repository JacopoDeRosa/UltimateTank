using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class TacCamSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _tacCam;
    [SerializeField] private PlayerInput _input;


    public UnityEvent onTacCamEnter;
    public UnityEvent onTacCamExit;

    private void Awake()
    {
        if(_input)
        {
            _input.actions["TacCam"].started += OnTacCam;
        }
    }
    private void OnDestroy()
    {
        if (_input)
        {
            _input.actions["TacCam"].started -= OnTacCam;
        }
    }


    private void OnTacCam(InputAction.CallbackContext context)
    {
        if(_tacCam.activeInHierarchy)
        {
            _tacCam.SetActive(false);
            GameStatus.controlsLocked = false;
            onTacCamExit.Invoke();
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            _tacCam.SetActive(true);
            GameStatus.controlsLocked = true;
            onTacCamEnter.Invoke();
            Cursor.lockState = CursorLockMode.Confined;
        }


    }
}
