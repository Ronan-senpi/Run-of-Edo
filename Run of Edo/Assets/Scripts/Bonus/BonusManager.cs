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

    [Header("Range up")]
    [SerializeField]
    protected float rangeUpSpawnRate = 1.5f;

    [SerializeField]
    protected float rangeUpDuration = 10f;
    public float GetRangeUpDuration()
    {
        return speedUpDuration;
    }

    [SerializeField]
    protected float rangeUpModifier = 1.5f;
    public float GetRangepModifier()
    {
        return speedUpModifier;
    }

    [Header("Auto Range")]
    [SerializeField]
    protected float autoRangeSpawnRate = 1.5f;

    [SerializeField]
    protected float autoRangeDuration = 10f;
    public float GetAutoRangeDuration()
    {
        return autoRangeDuration;
    }

    [SerializeField]
    protected float autoRangeModifier = 1.5f;
    public float GetAutoRangeModifier()
    {
        return autoRangeModifier;
    }

    
    public bool IsAutoRange { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
