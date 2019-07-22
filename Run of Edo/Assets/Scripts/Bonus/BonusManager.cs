using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : Base, IManager
{
    [Header("Speed up")]
    [SerializeField]
    protected float speedUpSpawnRate = 1.5f;

    [SerializeField]
    protected float speedUpDuration = 10f;
    public float GetSpeedUpDuration()
    {
        return speedUpDuration;
    }

    [SerializeField]
    protected float speedUpModifier = 1.5f;
    public float GetSpeedUpModifier()
    {
        return speedUpModifier;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
