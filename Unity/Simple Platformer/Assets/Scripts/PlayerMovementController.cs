using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;


    private RaycastHit2D[] _groundCheckResults = new RaycastHit2D[1];
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private const float _groundCheckTolerance = 0.01f;

    private UnityEvent _jump = new UnityEvent();
    private UnityEvent _land = new UnityEvent();
    private UnityEvent _move = new UnityEvent();

    public event UnityAction Jump
    {
        add
        {
            _jump.AddListener(value);
        }
        remove
        {
            _jump.RemoveListener(value);
        }
    }

    public event UnityAction Land
    {
        add
        {
            _land.AddListener(value);
        }
        remove
        {
            _jump.RemoveListener(value);
        }
    }

    public event UnityAction Move
    {
        add
        {
            _move.AddListener(value);
        }
        remove
        {
            _move.RemoveListener(value);
        }
    }

    public float HorizontalVelocity => _rigidbody.velocity.x;
    private float HorizontalInput => Input.GetAxis("Horizontal");
    private bool JumpInput => Input.GetKeyDown(KeyCode.Space);

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ApplyHorizontalMovement();
        ApplyJumping();
        UpdateGround();
    }

    private void ApplyHorizontalMovement()
    {
        _rigidbody.velocity = new Vector2(HorizontalInput * _speed, _rigidbody.velocity.y);
        _move.Invoke();
    }

    private void ApplyJumping()
    {
        if (JumpInput && _isGrounded)
        {
            _rigidbody.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
    }

    private void UpdateGround()
    {
        bool previousIsGrounded = _isGrounded;
        _isGrounded = _rigidbody.Cast(-transform.up, _groundCheckResults, _groundCheckTolerance) != 0;

        if (previousIsGrounded && _isGrounded == false)
        {
            _jump.Invoke();
        }
        else if (previousIsGrounded == false && _isGrounded)
        {
            _land.Invoke();
        }
    }
}
