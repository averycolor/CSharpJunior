using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimationController : MonoBehaviour
{
    private const float FlipXThreshold = 0f;
    private const string LandTrigger = "Land";
    private const string JumpTrigger = "Jump";
    private const string HorizontalVelocityParameter = "Horizontal Velocity";

    private PlayerMovementController _movementController;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        StartListening();
    }

    private void OnDisable()
    {
        StopListening();
    }

    private void Start()
    {
        TryGetComponent(out _movementController);
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        StartListening();
    }

    private void Update()
    {
        if (_movementController.HorizontalVelocity != FlipXThreshold)
        {
            _spriteRenderer.flipX = _movementController.HorizontalVelocity < FlipXThreshold;
        }
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
        _animator.ResetTrigger(LandTrigger);
        _animator.SetTrigger(JumpTrigger);
    }

    private void OnLand()
    {
        _animator.ResetTrigger(JumpTrigger);
        _animator.SetTrigger(LandTrigger);
    }

    private void OnMove()
    {
        _animator.SetFloat(HorizontalVelocityParameter, Mathf.Abs(_movementController.HorizontalVelocity));
    }
}
