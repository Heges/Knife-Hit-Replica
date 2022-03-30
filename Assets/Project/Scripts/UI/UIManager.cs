using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIManager : MonoBehaviour
{
    [SerializeField] private UIMenu menu;
    [SerializeField] private UIGameOver gameOver;
    [SerializeField] private UIShop shop;
    [SerializeField] private UIScores scores;
    [SerializeField] private UIHUD hud;

    private void OnEnable()
    {
        UIMenu.ClickEndEvent += ShowGameEnd;
        UIMenu.ClickStartEvent += StartGame;
        UIGameOver.ClickMenuEvent += ShowGameMenu;
        UIGameOver.ClickRetryEvent += StartGame;
        GameManager.GameOverEvent += ShowGameOverTitle;
        UIMenu.ClickShopEvent += ShowShop;
        UIShop.ClickMenuEvent += ShowGameMenu;
    }

    private void OnDisable()
    {
        UIMenu.ClickEndEvent -= ShowGameEnd;
        UIMenu.ClickStartEvent -= StartGame;
        UIGameOver.ClickMenuEvent -= ShowGameMenu;
        UIGameOver.ClickRetryEvent -= StartGame;
        GameManager.GameOverEvent -= ShowGameOverTitle;
        UIMenu.ClickShopEvent -= ShowShop;
        UIShop.ClickMenuEvent -= ShowGameMenu;
    }

    private void Start()
    {
        ShowGameMenu();
    }

    public void StartGame()
    {
        StartEvent?.Invoke();
        scores.Active();
        hud.Active();
    }

    public void ShowGameEnd()
    {
        EndEvent?.Invoke();
    }

    private void ShowGameMenu()
    {
        scores.Deactivate();
        menu.ActiveDeactiveMenu();
    }

    private void ShowGameOverTitle(PlayerData data)
    {
        scores.Deactivate();
        hud.Deactive();
        gameOver.GameOver(data);
    }

    private void ShowShop()
    {
        scores.Deactivate();
        hud.Deactive();
        shop.ActivateDeactivate();
    }
}
