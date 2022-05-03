using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groudgCheckRadius;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _groudLayer;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isOnGround;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Flip();
        CheckGround();
        
            _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody.velocity.y);     
            _animator.SetBool("IsRunning", Input.GetAxis("Horizontal") != 0);      

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    private void CheckGround()
    {
        _isOnGround = Physics2D.OverlapCircle(_groundCheckPoint.position, _groudgCheckRadius, _groudLayer);
    }
}
