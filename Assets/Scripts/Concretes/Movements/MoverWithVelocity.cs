using TreasureHunt.Abstracts.Movements;
using TreasureHunt.Controllers;
using UnityEngine;

namespace TreasureHunt.Movements
{
    public class MoverWithVelocity : IMover
    {
        Rigidbody2D rb;

        float _moveSpeed = 200f;

        public Vector2 MoveDirection { get; private set; }



        public MoverWithVelocity(PlayerController playerController)
        {
            rb = playerController.GetComponent<Rigidbody2D>();
        }
        public void Tick(float horizontal, float vertical)
        {
            //adVector2 direction = new Vector2(horizontal, vertical).normalized;

            Vector2 _normalizedMoveDirection = new Vector2(horizontal, vertical).normalized;


            MoveDirection = new Vector2(_normalizedMoveDirection.x * _moveSpeed, _normalizedMoveDirection.y * _moveSpeed);
            rb.velocity = MoveDirection * Time.fixedDeltaTime;
        }
        public Vector2 GetMoveDirection()
        {
            return MoveDirection;
        }

    }
}

