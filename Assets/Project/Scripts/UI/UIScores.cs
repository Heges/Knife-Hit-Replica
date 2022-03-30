using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScores : MonoBehaviour
{
    [SerializeField] private TMP_Text scores;
    [SerializeField] private TMP_Text apples;

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

    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void ChangeScore(int value)
    {
        score = value;
        scores.text = score.ToString();
    }

    private void ChangeApple(int value)
    {
        apple = value;
        apples.text = apple.ToString();
    }
}
