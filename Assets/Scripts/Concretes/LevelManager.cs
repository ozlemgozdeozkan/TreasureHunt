using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int _currentLevel;

    public GameObject[] _levels;

    public GameObject WinPanel;

    public GameObject LosePanel;


    private void Awake()
    {
        _levels[PlayerPrefs.GetInt("CurrentLevel")].SetActive(true);
    }

    private void SkipToNextLevel()
    {
        _currentLevel++;
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);

        if (_currentLevel < _levels.Length)
        {
            GameObject nextLevelObject = _levels[_currentLevel];
            _levels[_currentLevel - 1].SetActive(false);

            nextLevelObject.SetActive(true);
        }
        else
        {
            WinPanel.SetActive(true);
        }
    }

    public void CheckNextLevel(int entry, string playerType)
    {
        Scoreboard scoreboard = Scoreboard.Instance;
        if (entry == 10)
        {
            if (playerType == "Player")
            {
                SkipToNextLevel();
            }
            else if (playerType == "Competitor")
            {
                LosePanel.SetActive(false);
            }

        }
    }

    public void RestartGame()
    {
        _currentLevel = 0;
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}