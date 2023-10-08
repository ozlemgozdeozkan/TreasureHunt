using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreasureHunt.Controllers
{
    public class TreasureController : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 5.00f;

        [SerializeField] private float _minDistanceBetweenPlayer = 0.00f;       

        private float _elapsedTime = 0.00f;


        private System.Action OnEndLifeTime = null;
        private System.Action OnCollect = null;

        private BoxCollider2D _boxCollider = null;


        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider2D>();

            CheckForConditions();
        }

        private void CheckForConditions()
        {
            Collider2D[] _colliders = Physics2D.OverlapCircleAll(transform.position, 1.00f);

            foreach (Collider2D collider in _colliders)
            {
                if (collider.Equals(_boxCollider))
                    continue;

               // Debug.Log($"eski Konum: {transform.position}");
                transform.position = TreasureHunt.Spawners.TreasureSpawner.Instance.GetRandomSpawnPoint();
               // Debug.Log($"yeni Konum: {transform.position}");

                CheckForConditions();
                return;
            }

            float distance = Mathf.Abs(Vector2.Distance(PlayerController.Instance.transform.position, transform.position));

            if (distance <= _minDistanceBetweenPlayer)
            {
                transform.position = TreasureHunt.Spawners.TreasureSpawner.Instance.GetRandomSpawnPoint();
                CheckForConditions();
            }

            //print(distance);
        }


        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _lifeTime)
            {
                Destroy(this.gameObject);

                OnEndLifeTime?.Invoke();
            }
        }

        public void AddListenerToEndLifeAction(System.Action _action) => OnEndLifeTime += _action;
        public void AddListenerToOnCollectAction(System.Action _action) => OnCollect += _action;


        public void Collect()
        {
            OnCollect?.Invoke();
                      
            //CountdownTimer countdownTimer = FindObjectOfType<CountdownTimer>();
            //if (countdownTimer != null)
            //{
            //    countdownTimer.ResetTimer();
            //}
            Destroy(gameObject);
        }
    }
}