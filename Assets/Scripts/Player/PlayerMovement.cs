using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]


public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed;
    private bool _canMove;

    private Rigidbody2D _rigidbody;

    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _canMove = true;
    }


    private void Update()
    {
        TurnInMoveDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void TurnInMoveDirection()
    {
        if (_rigidbody.velocity.x > 0.01f)
            transform.localScale = new Vector2(1f, 1f);
        else if (_rigidbody.velocity.x < -0.01f)
            transform.localScale = new Vector2(-1f, 1f);
    }
    public void Move()
    {
        if (_canMove == false) return;

        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }

    public void EnableMove() => _canMove = true;
    public void DisableMove() => _canMove = false;
}
