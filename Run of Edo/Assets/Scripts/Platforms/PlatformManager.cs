﻿using System;
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
        //CreatePlatform();
        for (int i = 0; i < 5; i++)
        {
            AddPlatform();
        }
    }

    private void Update()
    {
        //CreatePlatform();
    }
    protected int RandIndexPlatform()
    {
        return Random.Range(0, platforms.Length);
    }

    public void AddPlatform()
    {
        Transform oldPlatform = platformContainer.GetChild(platformContainer.childCount - 1);
        Transform endOldPlatform = oldPlatform.Find("End");

        GameObject newPlat = Instantiate(platforms[RandIndexPlatform()], PositionModifier(endOldPlatform.position), Quaternion.identity);
        newPlat.transform.parent = platformContainer;
        //newPlat.GetComponent<PlatformController>().autoMoveState();
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
        Debug.Log(y);
        return y;
    }
}