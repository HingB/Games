using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayersSpriteAndColliderController : MonoBehaviour
{
    private uint _coins;
    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_playerMovement.MoveDirection > 0)
            _spriteRenderer.flipX = false;
        else if (_playerMovement.MoveDirection < 0)
            _spriteRenderer.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coins++;
            Destroy(coin.gameObject);
        }
    }
}
