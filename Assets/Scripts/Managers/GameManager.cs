using System;
using TheSnake;
using UnityEngine;

internal class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event Action<int> GotFood;
    public event Action<int> GotBodyPart;
    public event Action PlayerLost;
    public GameObject snake { get; private set; }
    public void Awake()
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
        snake = FindAnyObjectByType<SnakeMovement>().gameObject;
    }

    public void AddPoints(int points)
    {
        GotFood?.Invoke(points);
    }

    public void AddBodyParts(int growthAmount)
    {
        GotBodyPart?.Invoke(growthAmount);
    }

    public void PlayerHasLost()
    {
        PlayerLost?.Invoke();
    }
}