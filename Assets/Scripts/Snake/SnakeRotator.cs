using UnityEngine;

namespace TheSnake
{
    public class SnakeRotator : Snake
    {
        protected override void Update()
        {
            base.Update();
            Vector3 movementDirection = new(horizontal, 0, vertical);
            if (movementDirection.magnitude >= -1f && movementDirection.magnitude <= 1f)
            {
                movementDirection.Normalize();
            }

            if (movementDirection != Vector3.zero)
            {
                transform.forward = movementDirection;
            }
        }
    }
}