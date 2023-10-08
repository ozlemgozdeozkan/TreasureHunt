using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreasureHunt.Abstracts.Movements
{
    public interface IMover
    {
        Vector2 GetMoveDirection();
        void Tick(float horizontal, float vertical);
    }
}