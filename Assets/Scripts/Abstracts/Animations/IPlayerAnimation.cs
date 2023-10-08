using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreasureHunt.Animations
{
    public interface IPlayerAnimation 
    {
        void MoveAnimation(float horizontal, float vertical);
    }
}