using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private int _directionRight = 1;
    private int _directionLeft = -1;
    private int _directionZero = 0;

    public void AnimateMovement(float input)
    {
        switch (input)
        {
            case 1:
                _animator.SetInteger("Direction", _directionRight);
                break;
            case -1:
                _animator.SetInteger("Direction", _directionLeft);
                break;
            case 0:
                _animator.SetInteger("Direction", _directionZero);
                break;
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
