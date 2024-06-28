using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _minimumMoveSpeed = 0.8f;
    [SerializeField] float _maximumMoveSpeed = 2.9f;
    [SerializeField] float _damage;
    [SerializeField] float _hitWaitTime = 0.5f;
    
    float _moveSpeed;
    float _hitCounter;
    Transform _target;
    SpriteRenderer _spriteRenderer;
    CircleCollider2D _circleCollider;
    Vector2 _colliderOffset;
    Vector2 _colliderOffsetReversed;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _moveSpeed = Random.Range(_minimumMoveSpeed, _maximumMoveSpeed);
        _circleCollider = GetComponent<CircleCollider2D>();
        _colliderOffset = new Vector2(-0.18f, -0.16f);
        _colliderOffsetReversed = new Vector2(0.18f, -0.16f);
    }

    void Start()
    {
        _target = FindObjectOfType<PlayerMovement>().transform;
    }

    void FixedUpdate()
    {
        _rb.velocity = (_target.position - transform.position).normalized * _moveSpeed;
        
        if (_rb.velocity.x <= -0.01f)
        {
            _spriteRenderer.flipX = true;
            _circleCollider.offset = _colliderOffsetReversed;
        }
        else
        {
            _spriteRenderer.flipX = false;
            _circleCollider.offset = _colliderOffset;
        }

        if (_hitCounter > 0)
        {
            _hitCounter -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<PlayerHealth>();
        if (!player) return;
        
        PlayerHealth.Instance.TakeDamage(_damage);
        _hitCounter = _hitWaitTime;
    }
}
