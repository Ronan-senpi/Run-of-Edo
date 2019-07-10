using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Base, IManager
{
    [SerializeField]
    protected GameObject[] platforms;

    protected float maxYScrean = 1f;
    protected float minYScrean = -4f;

    protected Transform platformContainer;
    protected override void Awake()
    {
        base.Awake();
        platformContainer = transform.Find("PlatformContainer");
        //Try to instentiate platforms
    }


    public void AddPlatform()
    {
        
    }
}
