using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : View
{
    [SerializeField] private Text appleText;
    [SerializeField] private Text scoreText;
    public override void Initialize()
    {

    }

    public void OnClickRetry()
    {
        
    }

    public void OnClickMenu()
    {
        
    }

    public void SetApplesTextUI(string value)
    {
        appleText.text = value;
    }

    public void SetScoresTextUI(string value)
    {
        scoreText.text = value;
    }

    public void GameOver(PlayerData stats)
    {
        SetApplesTextUI(stats.Apple.ToString());
        SetScoresTextUI(stats.MaxRecord.ToString());
    }
}
