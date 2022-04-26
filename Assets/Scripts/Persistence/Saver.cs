using UnityEngine;
using System.IO;

public static class Saver
{
    private static string _path = Application.persistentDataPath + "/";

    public static void Save(IPersistent persitedObject)
    {
        if(persitedObject.Id == "" || persitedObject.Id == null)
        {
            throw new System.ArgumentException("Object has no id");
        }
        File.WriteAllText(_path + persitedObject.Id, JsonUtility.ToJson(persitedObject));
    }

    public static void Load(IPersistent persitedObject) 
    {
        if(File.Exists(_path + persitedObject.Id))
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(_path + persitedObject.Id), persitedObject);
        }
    }
}
