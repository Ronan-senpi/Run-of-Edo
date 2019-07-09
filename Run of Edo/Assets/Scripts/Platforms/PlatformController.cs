using Platform;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : AutoMoveController
{
    protected PlatformManager PlatformManager { get; set; }
    protected override void Awake()
    {
        base.Awake();
        this.PlatformManager = FindManager<PlatformManager>("PlatformManager");
    }
}
