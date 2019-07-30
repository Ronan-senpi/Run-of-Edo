using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstoppableShotBody : ShotBody
{
    protected GameManager gameManager;
    protected void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override void ExitDestroy()
    {
        base.ExitDestroy();
    }
    public override void ShotDestroy()
    {
        if (gameManager.BonusManager.IsAutoRange)
        {
            base.ShotDestroy();
        }
    }
}
