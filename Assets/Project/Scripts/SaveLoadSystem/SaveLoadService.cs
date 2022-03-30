using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadService
{
    public static string path = Application.persistentDataPath + "/saves";
    public static string name = "SavedConfig";

    public static bool Save(SaveData saveData)
    {
        try
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (!Directory.Exists(Application.persistentDataPath + "/saves"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/saves");
            }

            FileStream file = File.Create(path + "/" + name);
            binaryFormatter.Serialize(file, saveData);
            file.Close();
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public static PlayerData Load()
    {
        try
        {
            if (!Directory.Exists(Application.persistentDataPath + "/saves"))
            {
                return new PlayerData(0, 0);
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(path + "/" + name, FileMode.Open);

            object loaded = formatter.Deserialize(file);
            file.Close();

            SaveData savedData = loaded as SaveData;
            PlayerData data = new PlayerData(savedData.apples, savedData.record, savedData.currentKnife, savedData.ownedKnifes);
            return data;
        }
        catch (System.Exception)
        {
            Debug.Log("NE LOADED");
            return new PlayerData(0, 0);
        }
    }

    public static bool ClearSave()
    {
        try
        {
            File.Delete(path + "/" + name);
            return true;
        }
        catch (System.Exception)
        {
            Debug.Log("CANT DELETE FILE DOESNT FOUND");
            return false;
        }
    }
}
