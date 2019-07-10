using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBody : Destroyable
{
    public override void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
