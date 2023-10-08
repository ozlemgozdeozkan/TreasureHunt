using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TreasureHunt.Abstract.Scores
{
    public interface DisplayScore
    {
      
        private void Awake(TextMeshProUGUI _scoreText)
        {
            
        }

        private void OnEnable()
        { 
        }

        private void OnDisable()
        {
            
        }

        private void UpdateScoreText(TextMeshProUGUI _scoreText, int treasureCount) => _scoreText.SetText(treasureCount.ToString());
    }
}

