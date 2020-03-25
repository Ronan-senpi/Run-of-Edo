using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public ScoreData(float lastScore)
    {
        this.LastScore = lastScore;
        if (lastScore > this.HiScore)
        {
            this.HiScore = lastScore;
        }
    }
    public float HiScore { get; set; }
    public float LastScore { get; set; }
}
