using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public partial class UIGameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text appleText;
    [SerializeField] private TMP_Text scoreText;

    public void OnClickRetry()
    {
        ClickRetryEvent?.Invoke();
        ActiveDeactiveGameOverTitle();
    }

    public void OnClickMenu()
    {
        ClickMenuEvent?.Invoke();
        ActiveDeactiveGameOverTitle();
    }

    public void SetApplesTextUI(string value)
    {
        appleText.text = value;
    }

    public void SetScoresTextUI(string value)
    {
        scoreText.text = value;
    }

    public void ActiveDeactiveGameOverTitle()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void GameOver(PlayerData stats)
    {
        SetApplesTextUI(stats.Apple.ToString());
        SetScoresTextUI(stats.MaxRecord.ToString());
        ActiveDeactiveGameOverTitle();
    }
}
