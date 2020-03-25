using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBody : Base, Destroyable
{
    protected PlatformManager platformManager;
    protected override void Awake()
    {
        base.Awake();
        if (GameManager != null)
            platformManager = GameManager.PlatformManager;
    }
    public void ExitDestroy()
    {
        Destroy(transform.parent.gameObject);
        platformManager.AddPlatform();
    }
}
