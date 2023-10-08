using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreasureHunt.Abstracts.Statemachines {
    public interface IState 
    {
        void Tick();
        void OnEnter();
        void OnExit();
    }
}

