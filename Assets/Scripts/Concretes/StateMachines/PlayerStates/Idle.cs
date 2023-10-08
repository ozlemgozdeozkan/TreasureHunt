using TreasureHunt.Abstracts.Movements;
using TreasureHunt.Abstracts.Statemachines;
using TreasureHunt.Animations;


namespace TreasureHunt.StateMachines.PlayerStates
{
    public class Idle : IState      
    {
        IMover _mover;
        IPlayerAnimation _animation;

        public bool IsIdle { get; private set; }

        public Idle(IMover mover, IPlayerAnimation animation)
        {
            _mover = mover;
            _animation = animation;
        }
        public void OnEnter()
        {
            IsIdle = true;            
            _animation.MoveAnimation(0f, 0f);       

        }
        public void OnExit()
        {
            
        }
        public void Tick()
        {
            _mover.Tick(0f, 0f);
                                    
        }
    }

}
