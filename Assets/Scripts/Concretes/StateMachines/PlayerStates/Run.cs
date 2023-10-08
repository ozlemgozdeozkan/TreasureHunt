using TreasureHunt.Abstracts.Movements;
using TreasureHunt.Abstracts.Statemachines;
using TreasureHunt.Animations;
using UnityEngine;

namespace TreasureHunt.StateMachines.PlayerStates
{
    public class Run : IState
    {
        IMover _mover;
        IPlayerAnimation _animation;
        float _moveSpeed;

        Vector2 _direction = new Vector2 (1f,1f);

        public bool IsRunning { get; private set; }

        public Run(IMover mover, IPlayerAnimation animation)
        {
            _mover = mover;
            _animation = animation;
           
        }
        public void OnEnter()
        {
            _animation.MoveAnimation(1f, 1f);
            IsRunning = true;

            Debug.Log("Run On Enter");
        }

        public void OnExit()
        {
            
            _direction.x *= -1;
            _direction.y *= -1;

            _animation.MoveAnimation(0f, 0f);

            IsRunning = false;

            Debug.Log("Run On Exit");
        }

        public void Tick()
        {
            _mover.Tick(_direction.x, _direction.y);

            Debug.Log("Run Tick");
        }
    }

}
