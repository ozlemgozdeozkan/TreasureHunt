using TreasureHunt.Abstracts.Spawners;
using TreasureHunt.Controllers;
using UnityEngine;


namespace TreasureHunt.Spawners
{
    public class CompetitorSpawner : BaseSpawner
    {
        [SerializeField] CompetitorController[] competitors;

        private bool _isSpawned = false;

        protected override void Spawn()
        {
            if (_isSpawned)
                return;

            _isSpawned = true;
            int competitorIndex = Random.Range(0, competitors.Length);
            Instantiate(competitors[competitorIndex], this.transform);
        }
    }
}