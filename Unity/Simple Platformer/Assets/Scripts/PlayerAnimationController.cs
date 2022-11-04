using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimationController : MonoBehaviour
{
    private PlayerMovementController _movementController;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        TryGetComponent(out _movementController);
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        StartListening();
    }

    private void Update()
    {
        if (_movementController.HorizontalVelocity != 0)
        {
            _spriteRenderer.flipX = _movementController.HorizontalVelocity < 0f;
        }
    }

    private void OnEnable()
    {
        StartListening();
    }

    private void OnDisable()
    {
        StopListening();
    }

    private void StartListening()
    {
        if (_movementController)
        {
            _movementController.Jump += OnJump;
            _movementController.Land += OnLand;
            _movementController.Move += OnMove;
        }
    }

    private void StopListening()
    {
        if (_movementController)
        {
            _movementController.Jump -= OnJump;
            _movementController.Land -= OnLand;
            _movementController.Move -= OnMove;
        }
    }

    private void OnJump()
    {
        _animator.ResetTrigger("Land");
        _animator.SetTrigger("Jump");
    }

    private void OnLand()
    {
        _animator.ResetTrigger("Jump");
        _animator.SetTrigger("Land");
    }

    private void OnMove()
    {
        _animator.SetFloat("Horizontal Velocity", Mathf.Abs(_movementController.HorizontalVelocity));
    }
}
