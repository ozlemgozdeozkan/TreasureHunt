using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TreasureHunt.Controllers;

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard Instance { get; private set; } = null;

    [System.Serializable]
    public class ScoreEntry
    {
        public ScoreEntry(string playerName, int score)
        {
            _playerName = playerName;
            _score = score;
        }
        public ScoreEntry(string playerName)
        {
            _playerName = playerName;
            print($"New Register {playerName}");
        }
        public ScoreEntry()
        {
            _playerName = "";
            _score = 0;
        }

        private string _playerName = string.Empty;
        private int _score = 0;

        public string PlayerName => _playerName;

        public int Score { get => _score; set => _score = value; }
    }

    [SerializeField] private List<ScoreEntry> _scores = new List<ScoreEntry>();
    [SerializeField] private List<TextMeshProUGUI> _nickNameTexts = new List<TextMeshProUGUI>();
    [SerializeField] private List<TextMeshProUGUI> _scoreTexts = new List<TextMeshProUGUI>();


    private Dictionary<int, ScoreEntry> _scoreBoardDictionary = new Dictionary<int, ScoreEntry>();


    private static event System.Action<ScoreEntry> OnAddedNewItem = null;


    private void OnEnable()
    {
        OnAddedNewItem += CreateNewScore;

        PlayerController.OnChangedScore += UpdateScore;
        CompetitorController.OnTreasureCountChanged += UpdateScore;

    }
    private void OnDisable()
    {
        OnAddedNewItem -= CreateNewScore;

        PlayerController.OnChangedScore -= UpdateScore;
        CompetitorController.OnTreasureCountChanged -= UpdateScore;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (TextMeshProUGUI text in _nickNameTexts)
            text.SetText("");

        foreach (TextMeshProUGUI text in _scoreTexts)
            text.SetText("");
    }

    private void UpdateScore(int _hash, int _newScore)
    {
        ScoreEntry _score = _scoreBoardDictionary[_hash];
        _score.Score = _newScore;

        foreach (TextMeshProUGUI text in _nickNameTexts)
        {
            if (!text.text.Equals(_score.PlayerName))
                continue;

            _scoreTexts[_nickNameTexts.IndexOf(text)].SetText(_score.Score.ToString());
        }
    }

    public void AddItemToScoreBoard(int key, ScoreEntry _entry)
    {
        _scoreBoardDictionary.Add(key, _entry);
        OnAddedNewItem?.Invoke(_entry);
    }


    private void CreateNewScore<T>(T scoreEntry) where T : ScoreEntry
    {
        _nickNameTexts[_scoreBoardDictionary.Count - 1].SetText(scoreEntry.PlayerName);
        _scoreTexts[_scoreBoardDictionary.Count - 1].SetText(scoreEntry.Score.ToString());

    }
}

