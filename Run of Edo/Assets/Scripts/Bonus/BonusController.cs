﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonusController : AutoMoveController, Destroyable
{
    public void ExitDestroy()
    {
        Destroy(gameObject);
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    protected abstract void OnTriggerEnter2D(Collider2D collision);

}
 