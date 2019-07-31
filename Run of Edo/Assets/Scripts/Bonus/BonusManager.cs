using UnityEngine;

public class BonusManager : Base, IManager
{
    [SerializeField]
    [Range(0, 100)]
    protected int bonusDropRate = 5;
    [SerializeField]
    [Range(0, 100)]
    protected int MinCallBeforeSpawn = 25;

    #region BonusInit
    [Header("Speed up")]
    [SerializeField]
    [Range(0, 100)]
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
    [SerializeField]
    protected GameObject SpeedUpPrefab;

    [Header("Range up")]
    [SerializeField]
    [Range(0, 100)]
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
    [SerializeField]
    protected GameObject rangeUpPrefab;

    [Header("Auto Range")]
    [SerializeField]
    [Range(0, 100)]
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
    [SerializeField]
    protected GameObject autoRangePrefab;
    #endregion BonusInit


    protected int NbCall = 0;

    protected float TotalRateBonus { get { return autoRangeSpawnRate + speedUpSpawnRate + rangeUpSpawnRate; } }

    public bool IsAutoRange { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// Instanciate new bonus 
    /// </summary>
    /// <param name="position"></param>
    public void SetBonus(Vector3 position)
    {
        NbCall++;
        if (NbCall >= MinCallBeforeSpawn)
        {
            float mainRange = Random.Range(0f, 100f);
            if (mainRange <= bonusDropRate)
            {
                GameObject prefab = new GameObject("Mabite");
                float secondRange = Random.Range(0f, TotalRateBonus);
                //Speed up
                if (IsInRange(speedUpSpawnRate, secondRange, 0))
                {
                    prefab = SpeedUpPrefab;
                }
                //Range Up
                else if (IsInRange(speedUpSpawnRate + rangeUpSpawnRate, secondRange, 0 + speedUpSpawnRate))
                {
                    prefab = rangeUpPrefab;
                }
                //Auto range
                else if (IsInRange(speedUpSpawnRate + rangeUpSpawnRate + autoRangeSpawnRate, secondRange, speedUpSpawnRate + rangeUpSpawnRate))
                {
                    prefab = autoRangePrefab;
                }
                else
                {
                    return;
                }
                Debug.Log("nbcall : " + NbCall + " for " + prefab.name);
                NbCall = 0;
                position.y += 1;
                GameObject newPlat = Instantiate(prefab, position, Quaternion.identity);
                newPlat.transform.parent = transform;
            }
        }
    }
    protected bool IsInRange(float max, float value, float min)
    {
        return max > value && value > min;
    }
}
