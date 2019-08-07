using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerFollower : Base
{
    protected Transform tPlayer;

    protected override void Awake()
    {
        base.Awake();
        tPlayer = GameObject.Find("PlayerSub").transform;
    }
    protected virtual void Update()
    {
        transform.position = tPlayer.position;

    }
}
