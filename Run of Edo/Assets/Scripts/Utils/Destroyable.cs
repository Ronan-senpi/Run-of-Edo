using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Destroyable : Base
{
    protected float xLenght;
    protected override void Awake()
    {
        base.Awake();
        xLenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    public abstract void Destroy();
}
