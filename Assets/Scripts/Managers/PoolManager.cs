using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    public GameObject prefab;
    public int poolSize;
    public bool canGrow;
    public float timeBetweenFood = 1f;
    public List<GameObject> objectPool;
    public GameObject snake;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObject().SetActive(false);
        }

        StartCoroutine(PutFood());
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }

        if (canGrow)
        {
            return CreateNewObject();
        }

        return null;
    }

    private GameObject CreateNewObject()
    {
        GameObject newObject = Instantiate(prefab);
        newObject.transform.SetParent(transform);
        objectPool.Add(newObject);
        return newObject;
    }

    private IEnumerator PutFood()
    {
        yield return new WaitForSeconds(timeBetweenFood);

        GameObject obj = GetObject();
        if (obj != null)
        {
            obj.SetActive(true);
        }

        StartCoroutine(PutFood());
    }
    private void Update()
    {
        FindNearestFood();
    }
    public void FindNearestFood()
    {
        GameObject nearestFood = null;
        float nearestDistance = Mathf.Infinity;
        foreach (GameObject obj in objectPool)
        {
            if (obj.activeInHierarchy)
            {
                float distance = Vector3.Distance(snake.transform.position, obj.transform.position);
                if (distance < nearestDistance)
                {
                    nearestFood = obj;
                    nearestDistance = distance;
                }
                obj.GetComponent<Outline>().enabled = false;
            }
        }

        if (nearestFood)
        {
            nearestFood.GetComponent<Outline>().enabled = true;
        }
    }
}
