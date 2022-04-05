using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : View
{
    public override void Initialize()
    {
        
    }

    [SerializeField] private Text scores;
    [SerializeField] private Text apples;

    private int apple;
    private int score;

    private void OnEnable()
    {
        PlayerData.ChangeAppleEvent += ChangeApple;
        PlayerData.ChangeScoreEvent += ChangeScore;
        ChangeApple(GameManager.Player.GetApples());
        ChangeScore(0);
    }

    private void OnDisable()
    {
        PlayerData.ChangeAppleEvent -= ChangeApple;
        PlayerData.ChangeScoreEvent -= ChangeScore;
    }

    private void ChangeScore(int value)
    {
        score = value;
        scores.text = $"{score:D4}";
    }

    private void ChangeApple(int value)
    {
        apple = value;
        apples.text = $"{apple:D2}";
    }
}
