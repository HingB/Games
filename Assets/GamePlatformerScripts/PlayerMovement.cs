using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private float _groundRadius = 0.2f;
    private float _moveDirection;

    public bool IsGrounded => _isGrounded;
    public float MoveDirection => _moveDirection;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundLayer);

        _moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForse);
        }

        transform.Translate(Vector2.right * _moveDirection * _speed * Time.deltaTime);
    }
}
