using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public readonly int apples;
    public readonly int record;
    public readonly string currentKnife;
    public readonly List<string> ownedKnifes;

    public SaveData(PlayerData data)
    {
        apples = data.Apple;
        record = data.MaxRecord;
        currentKnife = data.CurrentKnife;
        ownedKnifes = data.OwnedKnifes;
    }
}
