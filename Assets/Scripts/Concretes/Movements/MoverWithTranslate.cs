using System.Collections;
using System.Collections.Generic;
using TreasureHunt.Abstracts.Movements;
using TreasureHunt.Controllers;
using UnityEngine;

namespace TreasureHunt.Movements
{
    public class MoverWithTranslate : IMover
    {
        PlayerController _playerController;
        float moveSpeed = 5f;
        public Vector2 MoveDirection { get; private set; }
        public MoverWithTranslate(PlayerController playerController)
        {
            _playerController = playerController;
        }
        public void Tick(float horizontal, float vertical)
        {
           // if (FloatingJoystick.horizontal == 0f && FloatingJoystick.vertical == 0f) return;

            Vector2 movement = new Vector2(horizontal, vertical); // Yatay ve dikey deðerleri birleþtir
            _playerController.transform.Translate(moveSpeed * Time.deltaTime * movement);
        }
        public Vector2 GetMoveDirection()
        {
            return MoveDirection;
        }
    }

}

