using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class mainCharacterController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private float _checkRadius;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _contactGround;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private bool _isGrounded;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_feetPosition.position, _checkRadius, _contactGround);

        if (_isGrounded == false)
            _animator.SetInteger("State", 2);

        if (_isGrounded == true && Input.GetKey(KeyCode.Space))
            Jump();

        if (Input.GetButton("Horizontal") && _isGrounded)
        {
            _animator.SetInteger("State", 1);
            Walk();
        }
        else
        {
            if(Input.GetButton("Horizontal"))
                Walk();
            if (_isGrounded)
            {
                _animator.SetInteger("State", 0);
            }
        }
    }

    private void Walk()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);

        _spriteRenderer.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}

