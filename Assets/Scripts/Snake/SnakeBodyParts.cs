using System;
using System.Collections.Generic;
using UnityEngine;
namespace TheSnake
{
    public class SnakeBodyParts : Snake
    {
        public int bodyGap = 10;
        public float bodySpeed = 5f;
        private List<Vector3> positionsHistory = new();
        public List<GameObject> bodyParts = new();
        public event Action<GameObject, bool> AddedBodyPart;
        private GameObject bodyPartsParent;
        private void Start()
        {
            GameManager.instance.GotBodyPart += GetBodyPart;
            bodyPartsParent = Instantiate(new GameObject());
            bodyPartsParent.name = "Body Parts Parent";
        }

        protected override void Update()
        {
            base.Update();
        }
        private void FixedUpdate()
        {
            MoveBodyParts();
        }

        private void MoveBodyParts()
        {
            if (horizontal != 0 || vertical != 0 || diagonal != 0)
            {
                positionsHistory.Insert(0, transform.position);
                for (int i = 0; i < bodyParts.Count; i++)
                {
                    Vector3 point = positionsHistory[Mathf.Min(i * bodyGap, positionsHistory.Count - 1)];
                    Vector3 moveDirection = point - bodyParts[i].transform.position;
                    bodyParts[i].transform.position += bodySpeed * Time.deltaTime * moveDirection;
                    bodyParts[i].transform.LookAt(point);
                }
            }
        }

        public void GetBodyPart(int growthAmount)
        {
            for (int i = 0; i < growthAmount; i++)
            {
                GameObject part = Instantiate(bodyPrefab);
                part.transform.parent = bodyPartsParent.transform;
                if (bodyParts.Count != 0)
                {
                    part.transform.position = bodyParts[^1].transform.position;
                    AddedBodyPart?.Invoke(part, true);
                    AddedBodyPart?.Invoke(bodyParts[^1], false);
                }
                else
                {
                    part.transform.position = transform.position;
                    AddedBodyPart?.Invoke(part, true);
                }
                bodyParts.Add(part);
            }
        }
    }
}