using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : AutoMoveController
{
    [SerializeField]
    protected float MinLocalModifie = 0.7f;

    public void LocalSpeedModifier(float value)
    {
        value = 1 - value;
        if (value < MinLocalModifie)
        {
            value = MinLocalModifie;
        }
        localSpeedModifier = value;
    }
}
