using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerMover : MonoBehaviour
{
    private const float OffsetX = 2f;

    private PlayerInput _input;
    private Vector2 _moveDirecton;
    private float _targetPosition;
    private Tween _animationOffset;
    private void Awake()
    {
        _input = new PlayerInput();
        _input.Player.Move.performed += context => Move();
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
        _moveDirecton = _input.Player.Move.ReadValue<Vector2>() * OffsetX;
        _targetPosition = _moveDirecton.normalized.x * transform.position.x;

        if (!_animationOffset.IsActive() && _targetPosition != 2)
        {
            StartCoroutine(ChangedOffset(_moveDirecton));
        }
    }

    private IEnumerator ChangedOffset(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, 0);       
        _animationOffset = transform.DOMoveX(transform.position.x + _moveDirecton.x, 0.12f);
        yield return _animationOffset.WaitForCompletion();
    }
}
