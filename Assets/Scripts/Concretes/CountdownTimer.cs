using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreasureHunt.Controllers;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private float _remainingTime = 0.00f;
    private float _startingTime = 60.00f;

    [SerializeField] public TextMeshProUGUI _countdownText;

    [SerializeField] public Image _countdownImage;

    [SerializeField] public Sprite _countdownSprite;

    private bool _isChanged = false;

    public GameObject LosePanel;

    private void Start()
    {
        _remainingTime = _startingTime;
        
    }
    private void Update()
    {
        _remainingTime -= 1 * Time.deltaTime;
        _remainingTime = Mathf.Clamp(_remainingTime, 0, float.PositiveInfinity);
        _countdownText.text = _remainingTime.ToString("0");

        

        if (_remainingTime <= 10 && !_isChanged)
        {
            _isChanged = true;
            _countdownImage.sprite = _countdownSprite;
        }

        if (_remainingTime <= 0)
        {
            LosePanel.SetActive(true);
        }       
    }
    public void ResetTimer()
    {
        _remainingTime = _startingTime;
        _isChanged = false;
    }


}