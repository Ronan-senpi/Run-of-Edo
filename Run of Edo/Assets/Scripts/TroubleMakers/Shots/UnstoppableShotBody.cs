using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstoppableShotBody : ShotBody
{
    public override void Destroy()
    {
        Debug.Log("Unstoppable !!!".ToUpper());
    }
}
