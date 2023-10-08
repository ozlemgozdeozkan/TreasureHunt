using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TreasureHunt.Controllers;
using TreasureHunt.Spawners;

[RequireComponent(typeof(CircleCollider2D))]
public class Radar : MonoBehaviour
{
    [SerializeField] private RadarLevelData _currentLevelData = null;

    [SerializeField] private List<RadarLevelData> _radarLevelDatas = null;
    [SerializeField] private Image _sensorImage = null;

    [SerializeField] private float _radarSensorRange = 5.00f;

    private CircleCollider2D _radarCollider = null;
    private RectTransform _canvasRectTransform = null;

    private PlayerController _playerController;
    private bool _canVibrate = true;
    public bool CanVibrate { get => _canVibrate; set => _canVibrate = value; }

    private RadarLevelData CurrentLevelData
    {
        get => _currentLevelData; set
        {
            _currentLevelData = value;

            _sensorImage.sprite = CurrentLevelData.GetRadarSprite();

            Vector2 _calculatedWidthHeight = (Vector2.one * 2) + (Vector2.one * (GetDataIndex(ref _currentLevelData) + 1));

            _canvasRectTransform.sizeDelta = _calculatedWidthHeight;
        }
    }

    private void Awake()
    {
        _radarCollider = GetComponent<CircleCollider2D>();
        _radarCollider.isTrigger = true;

        _canvasRectTransform = _sensorImage.transform.parent.GetComponent<RectTransform>();

        CurrentLevelData = _radarLevelDatas[0];

        _playerController = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        SetRadarLevel();
    }

    private RadarLevelData GetNextData() => _radarLevelDatas[GetDataIndex(ref _currentLevelData) + 1];
    private RadarLevelData GetPreviousData() => _radarLevelDatas[GetDataIndex(ref _currentLevelData) - 1];


    private int GetDataIndex<T>(ref T _data) where T : RadarLevelData => _radarLevelDatas.IndexOf(_data);



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utilities.HasTypeCollider(ref collision, out TreasureController _treasure))
        {
            int _radarLevel = GetDataIndex(ref _currentLevelData) + 1;

            _playerController.SetIsDig(true);
            _playerController.SetLastTreasure(ref _treasure);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Utilities.HasTypeCollider(ref collision, out TreasureController _treasure))
        {
            _playerController.SetIsDig(false);
            _playerController.SetLastTreasure(_value: null);
        }
    }

    private void SetRadarLevel()
    {
        float distance = Mathf.Abs(Vector2.Distance(transform.position, TreasureSpawner.Instance.Treasure.transform.position));

        int level = Mathf.FloorToInt(distance / _radarSensorRange);

        level = Mathf.Clamp(level, 1, _radarLevelDatas.Count);

        CurrentLevelData = _radarLevelDatas[^level];

        if (level.Equals(1) && CanVibrate)
            Vibrate();
    }

    private void Vibrate()
    {
        CanVibrate = false;

        Handheld.Vibrate();
    }
}