using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TacAction : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private GameObject _effectObject;
    [SerializeField] private float _lifeTime;

    [SerializeField] private ScoreKeeper _scoreKeeper;
    [SerializeField] private PlayerInput _input;



    private bool _targeting;
    private Vector2 _pointerPos;
    private Vector3 _spawnPoint;

    private void OnEnable()
    {
        if(_input)
        {
            _input.actions["PointerPos"].performed += OnPointerPos;
            _input.actions["Cancel"].started += OnCancel;
            _input.actions["Fire"].started += OnFire;
        }

    }

    private void OnDisable()
    {
        if (_input)
        {
            _input.actions["PointerPos"].performed -= OnPointerPos;
            _input.actions["Cancel"].started -= OnCancel;
            _input.actions["Fire"].started -= OnFire;
        }
    }

    public void Begin()
    {
        if(_scoreKeeper.TotalScore >= _cost)
        {
            _targeting = true;
        }
    }

    private void Cancel()
    {
        if (_targeting == false) return;
        _targeting = false;
    }

    private void OnPointerPos(InputAction.CallbackContext context)
    {
        _pointerPos = context.ReadValue<Vector2>();
    }

    private void OnCancel(InputAction.CallbackContext context)
    {
        Cancel();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        if(_targeting)
        {
            var effect = Instantiate(_effectObject, _spawnPoint, Quaternion.identity);
            _scoreKeeper.RemoveScore(_cost);
            Destroy(effect.gameObject, _lifeTime);
            _targeting = false;
        }
    }

    private void Update()
    {
        if(_targeting)
        {
            Ray ray = Camera.main.ScreenPointToRay(_pointerPos);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                _spawnPoint = hit.point;
            }
        }
    }
}
