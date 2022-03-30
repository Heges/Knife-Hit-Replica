using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public readonly PlayerData playerData;
    public readonly PlayerController playerController;
    public readonly KnifeConfig knifeConfig;

    public Player(KnifeSpawner spawner, KnifeConfig kConfig)
    {
        knifeConfig = kConfig;
        playerData = SaveLoadService.Load();
        knifeConfig.SetKnife(playerData.CurrentKnife);
        playerController = new PlayerController(spawner);
    }

    public void Subcribe()
    {
        playerData.Subcribe();
    }

    public void Unscribe()
    {
        playerData.Unscribe();
    }

    public void Save()
    {
        SaveData save = new SaveData(playerData);
        SaveLoadService.Save(save);
    }

    public void SetKnife(string name)
    {
        playerData.SetKnife(name);
        knifeConfig.SetKnife(name);
    }

    public int GetApples()
    {
        return playerData.Apple;
    }

    public void BuyItem(int value)
    {
        playerData.BuyItem(value);
    }

    public void ResetScore()
    {
        playerData.ResetScores();
    }

    public bool Contains(string name)
    {
        return playerData.Contains(name);
    }
}
