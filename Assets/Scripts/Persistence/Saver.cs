using UnityEngine;
using System.IO;

public static class Saver
{
    public static void Save(IPersistent persitedObject, string id)
    {
        File.WriteAllText(Application.persistentDataPath + "/" + id, JsonUtility.ToJson(persitedObject));
    }

    public static void Load(IPersistent persitedObject, System.Type type, string id) 
    {
        if(File.Exists(Application.persistentDataPath + "/" + id))
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.persistentDataPath + "/" + id), persitedObject);
        }
    }
}
