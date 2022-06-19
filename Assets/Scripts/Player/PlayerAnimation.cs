using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    public void AnimateMovement(float input)
    {
        switch (input)
        {
            case 1:
                _animator.SetInteger(AnimationStates.DirectionVariable, AnimationStates.DirectionRight);
                break;
            case -1:
                _animator.SetInteger(AnimationStates.DirectionVariable, AnimationStates.DirectionLeft);
                break;
            case 0:
                _animator.SetInteger(AnimationStates.DirectionVariable, AnimationStates.DirectionZero);
                break;
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}

public class AnimationStates
{
    public const string DirectionVariable = "Direction";
    public const int DirectionRight = 1;
    public const int DirectionLeft = -1;
    public const int DirectionZero = 0;
}
