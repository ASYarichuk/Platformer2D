using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;

    private Animator _animator;

    private bool _isGrounded;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (_isGrounded)
        {
            _animator.SetBool("IsGrounded", true);
        }
        else
        {
            _animator.SetBool("IsGrounded", false);
        }

        CheckInput();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetBool("Walking", true);
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("Walking", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetBool("Walking", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}
