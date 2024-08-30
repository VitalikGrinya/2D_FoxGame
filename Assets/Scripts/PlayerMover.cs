using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    private const string IsJump = "IsJump";
    private const string Speed = "Speed";

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isFaceRight = true;
    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
        Reflect();
        AnimateMovement();
    }

    public void Reset()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnEnable()
    {
        _groundChecker.IsGrounded += SetGround;
    }

    private void OnDisable()
    {
        _groundChecker.IsGrounded -= SetGround;
    }

    private void SetGround(bool IsGrounded)
    {
        _isGrounded = IsGrounded;
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && _isGrounded)
        {
            _animator.SetBool(IsJump, _isGrounded);

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
        else
        {
            _animator.SetBool(IsJump, !_isGrounded);
        }
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Reflect()
    {
        int moveLeft = 0;
        int moveRight = 180;

        if (Input.GetAxis("Horizontal") > 0 && _isFaceRight == true)
        {
            ReflectCondition(moveLeft);
        }

        if (Input.GetAxis("Horizontal") < 0 && _isFaceRight == false)
        {
            ReflectCondition(moveRight);
        }
    }

    public void AnimateMovement()
    {
        _animator.SetFloat(Speed, Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    private void ReflectCondition(int angle)
    {
        var transformRotation = transform.localRotation;
        transformRotation.y = angle;
        transform.localRotation = transformRotation;

        _isFaceRight = !_isFaceRight;
    }
}
