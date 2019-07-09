using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBody : Destroyable
{
    protected override void OnDestroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
