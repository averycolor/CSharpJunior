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

    private const float _flipXThreshold = 0f;
    private const string _landTrigger = "Land";
    private const string _jumpTrigger = "Jump";
    private const string _horizontalVelocityParameter = "Horizontal Velocity";

    private void Start()
    {
        TryGetComponent(out _movementController);
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        StartListening();
    }

    private void Update()
    {
        if (_movementController.HorizontalVelocity != _flipXThreshold)
        {
            _spriteRenderer.flipX = _movementController.HorizontalVelocity < _flipXThreshold;
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
        _animator.ResetTrigger(_landTrigger);
        _animator.SetTrigger(_jumpTrigger);
    }

    private void OnLand()
    {
        _animator.ResetTrigger(_jumpTrigger);
        _animator.SetTrigger(_landTrigger);
    }

    private void OnMove()
    {
        _animator.SetFloat(_horizontalVelocityParameter, Mathf.Abs(_movementController.HorizontalVelocity));
    }
}
