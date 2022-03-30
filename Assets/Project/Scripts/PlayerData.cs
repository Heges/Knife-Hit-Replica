using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData
{
    public delegate void ChangeScoreValueEventHandler(int value);
    public delegate void ChangeAppleValueEventHandler(int value);

    public static event ChangeScoreValueEventHandler ChangeScoreEvent;
    public static event ChangeAppleValueEventHandler ChangeAppleEvent;

    public int Apple => apple;
    public int MaxRecord
    {
        get
        {
            if (record > maxRecordBeforeStart)
            {
                return record;
            }
            return maxRecordBeforeStart;
        }
    }

    public List<string> OwnedKnifes => ownedKnifes;
    public string CurrentKnife => currentKnife;

    private int apple;
    private int record;
    private int maxRecordBeforeStart;

    private string currentKnife;
    private List<string> ownedKnifes;

    public PlayerData(int ap, int scr, string knife = "Deffault", List<string> ownKnifes = null)
    {
        apple = ap;
        record = 0;
        ownedKnifes = ownKnifes == null ? new List<string>(8) : ownKnifes;
        SetKnife(knife);
        maxRecordBeforeStart = scr;
    }

    public void Subcribe()
    {
        Knife.HitEvent += AddScores;
        AppleObstacle.AppleHitedEvent += AddAples;
    }

    public void Unscribe()
    {
        Knife.HitEvent -= AddScores;
        AppleObstacle.AppleHitedEvent -= AddAples;
    }

    public void AddScores()
    {
        record += UnityEngine.Random.Range(5,15);
        ChangeScoreEvent?.Invoke(record);
    }

    public void ResetScores()
    {
        if(maxRecordBeforeStart < record)
        {
            maxRecordBeforeStart = record;
        }

        record = 0;
        ChangeScoreEvent?.Invoke(record);
    }

    public void AddAples()
    {
        apple += 1;
        ChangeAppleEvent?.Invoke(apple);
    }

    public void AddSomeApples(int value)
    {
        apple += value;
        ChangeAppleEvent?.Invoke(apple);
    }

    public void BuyItem(int value)
    {
        apple -= value;
        ChangeAppleEvent?.Invoke(apple);
    }

    public bool Contains(string name)
    {
        return ownedKnifes.Contains(name);
    }

    public void SetKnife(string name)
    {
        if(ownedKnifes != null)
        {
            if (!ownedKnifes.Contains(name))
            {
                currentKnife = name;
                ownedKnifes.Add(currentKnife);
            }
            else
            {
                currentKnife = name;
            }
        }
    }
}
