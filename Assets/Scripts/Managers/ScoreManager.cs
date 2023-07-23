using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text_Score;
    private int gameScore;
    public int winScore;
    private readonly string scoreString = "Score: ";
    public event Action PlayerWon;
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
        GameManager.instance.GotFood += AddScore;
        text_Score.text = scoreString;
    }
    private void AddScore(int score)
    {
        gameScore += score;
        text_Score.text = scoreString + gameScore.ToString();
        CheckForWin();
    }

    private void CheckForWin()
    {
        if (winScore <= gameScore)
        {
            PlayerWon?.Invoke();
        }
    }
}
