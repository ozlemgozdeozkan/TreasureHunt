using TMPro;
using TreasureHunt.Abstracts.Inputs;
using TreasureHunt.Abstracts.Movements;
using TreasureHunt.Animations;
using TreasureHunt.Inputs;
using TreasureHunt.Movements;
using TreasureHunt.StateMachines;
using TreasureHunt.StateMachines.PlayerStates;
using UnityEngine;


namespace TreasureHunt.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; } = null;

        IPlayerInput _input;
        IMover _mover;
        IPlayerAnimation _animation;


        StateMachine _stateMachine;

        private float _horizontal;
        private float _vertical;

        private Vector2 lastMoveDirection;

        [SerializeField] private FloatingJoystick _floatingJoystick;
        public FloatingJoystick Joystick => _floatingJoystick;

        [SerializeField] public static int _treasureCount = 0;
      
        public int TreasureCount
        {
            get { return _treasureCount; }
            set
            {
                _treasureCount = value;
                OnChangedScore?.Invoke(GetHashCode(), TreasureCount);
            }
        }
        public static event System.Action<int, int> OnChangedScore = null;
        public void SetTreasureCount(int _count) => TreasureCount = _count;
        public void IncreaseTreasureCount(int _increaseAmount) => SetTreasureCount(TreasureCount + _increaseAmount);


        private bool _isDig = false;
        private TreasureController _lastTreasure = null;

        public void SetLastTreasure<T>(ref T _refValue) where T : TreasureController => _lastTreasure = _refValue;
        public void SetLastTreasure(TreasureController _value) => _lastTreasure = _value;

        /*public void SetLastTreasures<T>(T _refValue) where T: TrasureController
         {
             _lastTreasure = _refValue;
         }*/

        public TreasureController GetLastTreasure() => _lastTreasure;

        public void SetIsDig(bool value) => _isDig = value;

        private void Awake()
        {
            Instance = this;

            _input = new JoystickInput(ref _floatingJoystick);

            _mover = new MoverWithVelocity(this);
            _animation = new CharacterAnimation(GetComponent<Animator>());
            _stateMachine = new StateMachine();
            
        }

        private void Start()
        {
            Idle idle = new Idle(_mover, _animation);
            Run run = new Run(_mover, _animation);
            Dig dig = new Dig(this, GetComponent<Animator>());

            _stateMachine.AddTransition(idle, run, () => idle.IsIdle == false);
            _stateMachine.AddTransition(run, idle, () => !run.IsRunning);

            _stateMachine.AddTransition(idle, dig, () => _isDig);
            _stateMachine.AddTransition(run, dig, () => _isDig);

            _stateMachine.AddTransition(dig, to: idle, () => !_isDig && idle.IsIdle);

            _stateMachine.SetState(idle);

            Scoreboard.Instance.AddItemToScoreBoard(GetHashCode(), new Scoreboard.ScoreEntry(playerName: "Player"));
        }

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            //Gizmos.DrawWireSphere(transform.position, treasureDistance);
        }

        private void Update()
        {
            _stateMachine.Tick();

            _horizontal = _input.Horizontal;

            _vertical = _input.Vertical;

            _animation.MoveAnimation(_horizontal, _vertical);
            lastMoveDirection = _mover.GetMoveDirection();
        }
        private void FixedUpdate()
        {
            _mover.Tick(_horizontal, _vertical);
           
        }

    }
}