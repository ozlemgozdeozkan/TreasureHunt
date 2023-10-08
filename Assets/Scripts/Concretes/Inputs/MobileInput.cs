using TreasureHunt.Abstracts.Inputs;
using UnityEngine;

namespace TreasureHunt.Inputs
{
    public class MobileInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxisRaw("Horizontal");

        public float Vertical => Input.GetAxisRaw("Vertical");
    }


    public class JoystickInput : IPlayerInput
    {
        private FloatingJoystick _floatingJoystick = null;

        public JoystickInput(ref FloatingJoystick _floatingJoystick)
        {
            this._floatingJoystick = _floatingJoystick;
        }

        public float Horizontal => _floatingJoystick.Horizontal;

        public float Vertical => _floatingJoystick.Vertical;
    }

}