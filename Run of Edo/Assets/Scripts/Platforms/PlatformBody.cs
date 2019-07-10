using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBody : Destroyable
{
    protected PlatformManager platformManager;
    protected override void Awake()
    {
        base.Awake();
        platformManager = FindManager<PlatformManager>("PlatformManager");
    }
    public override void Destroy()
    {
        Destroy(transform.parent.gameObject);
        platformManager.AddPlatform();
    }
}
