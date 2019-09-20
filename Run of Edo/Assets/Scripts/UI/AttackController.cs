using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackController : TapController
{
    protected override void DoSomthingInternal()
    {
        IsPressed = false;
    }
}
