using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public ScoreData(float lastScore, float hiScore)
    {
        this.LastScore = lastScore;
        if (lastScore > hiScore)
            this.HiScore = lastScore;
        else
            this.HiScore = hiScore;
    }
    public float HiScore { get; set; }
    public float LastScore { get; set; }
}
