using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayersAnimationController : MonoBehaviour 
{
    private Animator _animator;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float speedNow = _playerMovement.MoveDirection;

        if (speedNow > 0 || speedNow < 0)
            _animator.SetBool("IsRunning", true);
        else
            _animator.SetBool("IsRunning", false);

        _animator.SetBool("Jump", !_playerMovement.IsGrounded);
    }
}
