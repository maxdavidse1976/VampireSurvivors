using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody2D _rb;

    Animator _animator;
    SpriteRenderer _spriteRenderer;

    public bool isRunning;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        _spriteRenderer.flipX = moveInput.x < -0.1;

        _rb.velocity = moveInput * _moveSpeed;

        isRunning = moveInput != Vector3.zero;
        _animator.SetBool("isRunning", isRunning);
    }
}
