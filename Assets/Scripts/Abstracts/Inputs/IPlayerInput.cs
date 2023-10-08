using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreasureHunt.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        float Vertical { get; }
    }

}

