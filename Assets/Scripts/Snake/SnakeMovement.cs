using UnityEngine;

namespace TheSnake
{
    public class SnakeMovement : Snake
    {
        public float movementSpeed = 1f;
        public bool clampPosition;

        protected override void Update()
        {
            base.Update();
            Vector3 direction = new(horizontal, diagonal, vertical);

            //This if statement is to avoid creating a new vector object every frame if the snake isn't moving.
            if (direction.magnitude >= -1f && direction.magnitude <= 1f)
            {
                direction.Normalize();
            }
            MoveSnake(direction);
        }

        void MoveSnake(Vector3 direction)
        {
            Vector3 newPosition = transform.position += movementSpeed * Time.deltaTime * direction;

            if (clampPosition)
            {
                newPosition = ClampedPosition(newPosition);
            }

            transform.position = newPosition;
        }

        private Vector3 ClampedPosition(Vector3 pos)
        {
            pos.y = Mathf.Clamp(pos.y, 0.5f, 14.5f);
            pos.z = Mathf.Clamp(pos.z, -14.5f, 14.5f);
            pos.x = Mathf.Clamp(pos.x, -14.5f, 14.5f);
            return pos;
        }
    }
}