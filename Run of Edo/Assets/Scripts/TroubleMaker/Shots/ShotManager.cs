using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : Base, IManager
{
    PlayerController playerController;
    protected override void Awake()
    {
        base.Awake();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

}
