using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Base, IManager
{
    public PlayerController Controller { get; private set; }
    public RangeController Range { get; private set; }
    // Awake is called when the script instance is being loaded
    protected override void Awake()
    {
        base.Awake();
        Controller = GetComponentInChildren<PlayerController>();
        Range = GetComponentInChildren<RangeController>();
    }
}
