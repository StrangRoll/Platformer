using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovier : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;

    private Rigidbody2D _rigidbody;
    private bool _isOnGround = false;
    private float _speedY = 0;

    public void Move(float horizontalInput, float jumpInput)
    {
        Vector3 deltaXPos = transform.right * horizontalInput * _speed;

        if (jumpInput > 0 && _isOnGround == true)
        {
            _speedY = _jumpForce;
            _isOnGround = false;
        }

        if (_isOnGround == false)
        {
            _speedY -= _gravity;
        }

        Vector3 deltaYPos = transform.up * _speedY;
        _rigidbody.velocity = deltaXPos + deltaYPos;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Ground>(out Ground ground) && _speedY <= 0)
        {
            _speedY = 0;
            _isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isOnGround = false;
        }
    }
}
