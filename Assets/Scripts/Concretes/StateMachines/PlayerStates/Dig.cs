using System.Collections;
using System.Collections.Generic;
using TreasureHunt.Abstracts.Movements;
using TreasureHunt.Abstracts.Statemachines;
using TreasureHunt.Controllers;
using TreasureHunt.Animations;
using UnityEngine;

namespace TreasureHunt.StateMachines.PlayerStates
{
    public class Dig : IState
    {
        IPlayerAnimation _animation;

        private float _timeDuration = 2.00f, _elapsedTime = 0.00f;

        private PlayerController _controller = null;
        private Animator _animator = null;


        public Dig(PlayerController controller, Animator animator)
        {
            _controller = controller;
            _animator = animator;
        }
        public void OnEnter()
        {
            _animator.SetBool("IsDigging", true);
        }

        public void OnExit()
        {
            _animator.SetBool("IsDigging", false);
        }

        public void Tick()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < _timeDuration)
                return;

            _elapsedTime = 0.00f;

            _controller.GetLastTreasure().Collect();
            _controller.IncreaseTreasureCount(1);
            _controller.GetComponentInChildren<Radar>().CanVibrate = true;
        }
    }

}
