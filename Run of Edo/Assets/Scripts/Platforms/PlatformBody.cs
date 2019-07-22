using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBody : BaseController, Destroyable
{
    protected PlatformManager platformManager;
    protected override void Awake()
    {
        base.Awake();
        platformManager = FindManager<PlatformManager>("PlatformManager");
    }
    public void ExitDestroy()
    {
        Destroy(transform.parent.gameObject);
        platformManager.AddPlatform();
    }
}
