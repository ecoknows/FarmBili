using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static void Save<T>(T objectToSave, string key)
    {
        string path = Application.persistentDataPath + "/saves/";
        Directory.CreateDirectory(path);
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream file = new FileStream(path + key + ".txt", FileMode.Create))
        {
            formatter.Serialize(file,objectToSave);
        }
        Debug.Log("Saved!");
    }

    public static T Load<T>(string key)
    {
        string path = Application.persistentDataPath + "/saves/";
        BinaryFormatter formatter = new BinaryFormatter();
        T returnValue = default(T);
        using (FileStream file = new FileStream(path + key + ".txt", FileMode.Open))
        {
            returnValue = (T) formatter.Deserialize(file);
        }
        return returnValue;
    }

    public static bool SaveExist(string key)
    {
        string path = Application.persistentDataPath + "/saves/" + key + ".txt";
        return File.Exists(path);
    }

    public static void DeleteFilesSaved(string key)
    {
        string path = Application.persistentDataPath + "/saves/" + key + ".txt";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete();
        directory.CreateSubdirectory(path);
    }

}
