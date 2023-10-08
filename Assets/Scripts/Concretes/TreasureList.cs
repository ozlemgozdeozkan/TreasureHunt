using UnityEngine;
using TreasureHunt.Controllers;
using System.Collections.Generic;

[System.Serializable]
public class TreasureList : List<TreasureController>
{
    public TreasureController GetRandomTreasure() => base[GetRandomIndex()];

    private int GetRandomIndex() => Random.Range(0, Count);
}