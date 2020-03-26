using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static readonly string path = Application.persistentDataPath + "/s.sav";
    public static void SaveScore(float lastScore)
    {
        float hiScore = 0;
        ScoreData score = loadScore();
        if (score != null)
        {
            hiScore = score.HiScore;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(lastScore, hiScore);

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
