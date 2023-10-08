using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreasureHunt.Controllers;
using UnityEngine;


namespace TreasureHunt.Ui
{
    public class DisplayScore : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI _scoreText;

        private PlayerController _playerController;

        private CompetitorController _competitorController;

        public string playerName;
        public int score;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _playerController = PlayerController.Instance;
            _competitorController = CompetitorController.Instance;
        }

        private void OnEnable()
        {
            if (!_playerController)
                _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            //_playerController.OnTreasureCountChanged += UpdateScoreText;

            if (!_competitorController)
                _competitorController = GameObject.FindGameObjectWithTag("Competitor").GetComponent<CompetitorController>();
            //_competitorController.OnTreasureCountChanged += UpdateScoreText;
        }

        private void OnDisable()
        {
            //_playerController.OnTreasureCountChanged -= UpdateScoreText;

           // _competitorController.OnTreasureCountChanged -= UpdateScoreText;
        }

        private void UpdateScoreText(int treasureCount) => _scoreText.SetText(treasureCount.ToString());

    }
}