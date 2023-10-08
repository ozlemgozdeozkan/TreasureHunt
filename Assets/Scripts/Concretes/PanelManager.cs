using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public Button RestartGameButton;
    public Button QuitGameButton;
    public GameObject GamePanel;

    public LevelManager _levelManager;
    public void ResumeButton()
    {
        GamePanel.SetActive(false);
        Time.timeScale = 1;
        
        _levelManager.RestartGame();
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
