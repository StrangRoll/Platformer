using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovier))]
[RequireComponent(typeof(PlayerAnimation))]

public class Player : MonoBehaviour
{
    private PlayerMovier _movier;
    private PlayerAnimation _animation;

    private void Start()
    {
        _movier = GetComponent<PlayerMovier>();
        _animation = GetComponent<PlayerAnimation>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float jumpInput = Input.GetAxisRaw("Jump");
        _movier.Move(horizontalInput, jumpInput);
        _animation.AnimateMovement(horizontalInput);
    }
}
