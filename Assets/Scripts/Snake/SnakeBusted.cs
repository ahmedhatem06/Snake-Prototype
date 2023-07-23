using UnityEngine;

namespace TheSnake
{
    public class SnakeBusted : MonoBehaviour
    {
        private readonly string wallTag = "Wall";
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(wallTag))
            {
                GameManager.instance.PlayerHasLost();
            }
        }
    }
}