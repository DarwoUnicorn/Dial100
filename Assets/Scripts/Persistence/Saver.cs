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

    public static bool Load(IPersistent persitedObject, string id) 
    {
        if(File.Exists(_path + id))
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(_path + id), persitedObject);
            return true;
        }
        return false;
    }
}
