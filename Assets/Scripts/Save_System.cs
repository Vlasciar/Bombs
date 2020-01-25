using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save_System
{
    private const string path_string = "/player.bbs";

    public static void Save_Player()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + path_string;
        FileStream stream = new FileStream(path, FileMode.Create);

        Player_Data data = new Player_Data();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Player_Data Load_Player()
    {
        string path = Application.persistentDataPath + path_string;
        if (!File.Exists(path))
        {
            Save_Player();
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        
        Player_Data data = formatter.Deserialize(stream) as Player_Data;
        stream.Close();

        return data;
    }
}