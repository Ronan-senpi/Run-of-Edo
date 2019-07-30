using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformManager : Base, IManager
{

    [SerializeField]
    protected float maxXJump = 7f;
    [SerializeField]
    protected float minXJump = 4f;

    [SerializeField]
    protected GameObject[] platforms;

    protected float maxY = 1f;
    protected float minY = -4f;

    protected float MaxJumpY = 2;

    protected float platformLenght = 0;

    protected Transform platformContainer;

    protected override void Awake()
    {
        base.Awake();
        platformContainer = transform.Find("PlatformContainer");
        FillPlatformContainer();
    }

    protected int RandIndexPlatform()
    {
        return Random.Range(0, platforms.Length);
    }

    protected Vector3 PositionModifier(Vector3 vector)
    {
        vector.y = YModifier(vector.y);
        vector.x = XModifier(vector.x);
        return vector;
    }

    private float XModifier(float x)
    {
        x += (float)Math.Round(Random.Range(minXJump, maxXJump), 0);
        return x;
    }

    protected float YModifier(float y)
    {
        float LocalMaxY = y + MaxJumpY;
        if (maxY < LocalMaxY)
        {
            LocalMaxY = maxY;
        }
        y = (float)Math.Round(Random.Range(minY, LocalMaxY), 1);
        return y;
    }
    protected void FillPlatformContainer()
    {
        for (int i = 0; i < 5 - (platformContainer.childCount > 5 ? 5 : platformContainer.childCount); i++)
        {
            AddPlatform();
        }
    }

    protected void Clear()
    {
        for (int i = 0; i < platformContainer.childCount; i++)
        {
            Destroy(platformContainer.GetChild(i).gameObject);
        }
    }

    public void AddPlatform()
    {
        Transform oldPlatform = platformContainer.GetChild(platformContainer.childCount - 1);
        Transform endOldPlatform = oldPlatform.Find("End");

        GameObject newPlat = Instantiate(platforms[RandIndexPlatform()], PositionModifier(endOldPlatform.position), Quaternion.identity);
        newPlat.transform.parent = platformContainer;
        GameManager.BonusManager.SetBonus();
    }

    public void AddPlatform(Vector3 position)
    {
        GameObject newPlat = Instantiate(platforms[RandIndexPlatform()], position, Quaternion.identity);
        newPlat.transform.parent = platformContainer;
    }
    /// <summary>
    /// Remove all platforms and create new ones, the first platform be created under playerPosition.y-1
    /// </summary>
    /// <param name="playerPosition"></param>
    public void ReloadPlatform(Vector3 playerPosition)
    {
        Clear();
        playerPosition.y -= 1;
        if (playerPosition.y < minY)
        {
            playerPosition.y = minY;
        }
        AddPlatform(playerPosition);
        FillPlatformContainer();
    }
}
