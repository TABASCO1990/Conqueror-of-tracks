using System;
using System.Dynamic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    private PlayerInput _input;
    private Transform _currenttransform;

    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Move.performed += context => Move();

        _currenttransform = transform;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Move()
    {
        Vector2 moveDirecton = _input.Player.Move.ReadValue<Vector2>();
        ChangedOffset(moveDirecton * 2);
    }

    private void ChangedOffset(Vector2 direction)
    {
        //Исправить метод
        Vector3 moveDirection = new Vector3(direction.x, 0, 0);

        if (transform.position.x > -2 && transform.position.x < 2)
        {
            
            transform.position += moveDirection;
        }
        else
        {
            moveDirection = transform.position;
            print("ff");
        }

    }
}
