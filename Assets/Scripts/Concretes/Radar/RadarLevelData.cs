using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableOjbects/RadarLevel")]
public class RadarLevelData : ScriptableObject
{
    [SerializeField] private Sprite _radarSprite = null;

    public Sprite GetRadarSprite() => _radarSprite;
}