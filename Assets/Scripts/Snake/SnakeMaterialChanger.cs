using UnityEngine;

namespace TheSnake
{
    public class SnakeMaterialChanger : Snake
    {
        private Material material_Black;
        private Material material_BodyPart;

        private void Start()
        {
            GetMaterials();

            GetComponent<SnakeBodyParts>().AddedBodyPart += ChangeMaterial;
        }

        private void GetMaterials()
        {
            material_Black = GetComponentInChildren<MeshRenderer>().material;
            material_BodyPart = bodyPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterial;
        }

        private void ChangeMaterial(GameObject bodyPart, bool isTail)
        {
            if (isTail)
            {
                bodyPart.GetComponentInChildren<MeshRenderer>().material = material_Black;
            }
            else
            {
                bodyPart.GetComponentInChildren<MeshRenderer>().material = material_BodyPart;
            }
        }
    }
}