using TreasureHunt.Controllers;
using UnityEngine;

namespace TreasureHunt.Spawners
{
    public class TreasureSpawner : MonoBehaviour
    {
        [SerializeField] TreasureController treasure;

        [SerializeField] private Transform _upLeftCorner = null, _bottomRightCorner = null;

        public static TreasureSpawner Instance { get; private set; } = null;

        private TreasureController _treasure = null;

        public TreasureController Treasure { get => _treasure; set => _treasure = value; }

        private void Awake()
        {
            Instance = this;
        }


        private void Start()
        {
            Spawn();
        }

        protected void Spawn()
        {
            TreasureController _lastSpawnedTreasure = Instantiate(treasure, GetRandomSpawnPoint(), Quaternion.identity);

            _lastSpawnedTreasure.AddListenerToEndLifeAction(Spawn);
            _lastSpawnedTreasure.AddListenerToOnCollectAction(Spawn);

            Treasure = _lastSpawnedTreasure;
        }

        public Vector2 GetRandomSpawnPoint()
        {
            float x = Random.Range(_upLeftCorner.position.x, _bottomRightCorner.position.x);
            float y = Random.Range(_upLeftCorner.position.y, _bottomRightCorner.position.y);

            return new Vector2(x, y);
        }
    }
}