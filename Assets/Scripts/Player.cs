using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    [SerializeField] private uint _coins;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private float _groundRadius = 0.2f;
    private float _moveDirection;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundLayer);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            _moveDirection = 1;
            _spriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
            _moveDirection = 1;
            _spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForse);
        }

        if(Input.GetKey(KeyCode.A)  == false && Input.GetKey(KeyCode.D) == false)
        {
            _moveDirection = 0;
        }
        
        _animator.SetFloat("Speed", _moveDirection);
        _animator.SetBool("Jump", !_isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coins++;
            Destroy(coin.gameObject);
        }
    }
}
