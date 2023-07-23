using UnityEngine;

namespace TheSnake
{
    public class Snake : MonoBehaviour
    {
        [SerializeField]
        public GameObject bodyPrefab;
        public float horizontal { get; private set; }
        public float vertical { get; private set; }
        public float diagonal { get; private set; }
        protected virtual void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            diagonal = Input.GetAxis("Depth");
        }
    }
}