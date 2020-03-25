using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static readonly string path = Application.persistentDataPath + "/s.scr";
    public static void SaveScore(float lastScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(lastScore);

        formatter.Serialize(stream, data);
    }

    public static ScoreData loadScore()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("No save file in " + path);
            return null;
        }
    }
}
