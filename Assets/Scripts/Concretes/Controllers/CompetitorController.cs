using TMPro;
using TreasureHunt.Spawners;
using UnityEngine;
using UnityEngine.AI;

namespace TreasureHunt.Controllers
{
    public class CompetitorController : MonoBehaviour
    {
        public static CompetitorController Instance { get; private set; } = null;

        public int TreasureCount
        {
            get { return _treasureCount; }
            set
            {
                _treasureCount = value;
                OnTreasureCountChanged?.Invoke(GetHashCode(), TreasureCount);
            }
        }

        public static event System.Action<int, int> OnTreasureCountChanged;

        [SerializeField] float maxLifeTime = 2000f;

        float _currentTime;

        public Transform treasure;
        private NavMeshAgent _navMesh = null;

        private TreasureController _targetTreasure = null;

        [SerializeField] public static int _treasureCount = 0;

        private bool IsCollected = false;        

        private void Awake()
        {
            _navMesh = GetComponent<NavMeshAgent>();

            _navMesh.updateRotation = false;
            _navMesh.updateUpAxis = false;

        }

        private void Start()
        {
            _targetTreasure = TreasureSpawner.Instance.Treasure;
           
            Scoreboard.Instance.AddItemToScoreBoard(GetHashCode(), new Scoreboard.ScoreEntry(playerName: "Bot"));
        }

        private void Update()
        {
            GoTarget();
            _currentTime += Time.deltaTime;

            if (_currentTime > maxLifeTime)
            {
                Destroy(this.gameObject);
            }
        }

        void GoTarget()
        {
            if (_targetTreasure )
                _navMesh.SetDestination(_targetTreasure.transform.position);
            else
                _targetTreasure = TreasureSpawner.Instance.Treasure;
        }

       
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (Utilities.HasTypeCollision(ref collision, out TreasureController _controller))
            {
                if(IsCollected == false)
                {
                    IsCollected = true;
                   // Invoke(nameof(CollectControl), 3.00f);
                    _controller.Collect();
                    TreasureCount++;
                }    
               
            }
        }

        private void CollectControl()
        {
            IsCollected =false;
        }
    }

}