using UnityEngine;

namespace TreasureHunt.Abstracts.Spawners
{
    public abstract class BaseSpawner : MonoBehaviour
    {
        [Range(150f, 160f)]
        [SerializeField] float _maxSpawnTime = 160f;
        [Range(60f, 140f)]
        [SerializeField] float _minSpawnTime = 140f;

        float _currentSpawnTime;

        float _timeBoundary;

        private void Start()
        {
            ResetTime();
        }

        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            if (_currentSpawnTime > _timeBoundary)
            {
                Spawn();
                ResetTime();
            }
        }

        protected abstract void Spawn();
       
        private void ResetTime()
        {
            _currentSpawnTime = 0f;
            _timeBoundary = Random.Range(_minSpawnTime, _maxSpawnTime);
        }

    }

}
