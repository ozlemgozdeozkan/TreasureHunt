using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreasureHunt.Animations
{
    public class CharacterAnimation: IPlayerAnimation
    {
        public Vector2 MoveDirection { get; private set; }
        Animator _animator;
        Vector2 lastMoveDirection;
        public CharacterAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void MoveAnimation(float horizontal, float vertical)
        {
            MoveDirection = new Vector2(horizontal, vertical).normalized;

            if ((horizontal == 0 && vertical == 0) && MoveDirection.x != 0 || MoveDirection.y != 0)
            {
                lastMoveDirection = MoveDirection;
            }

            _animator.SetFloat("AnimMoveX", horizontal);
            _animator.SetFloat("AnimMoveY", vertical);
            _animator.SetFloat("AnimMoveMagnitude", Mathf.Sqrt(horizontal * horizontal + vertical * vertical));
            _animator.SetFloat("AnimLastMoveX", lastMoveDirection.x);
            _animator.SetFloat("AnimLastMoveY", lastMoveDirection.y);

        }

    }
}

