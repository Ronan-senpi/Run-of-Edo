using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveController : Base
{
    [SerializeField]
    protected bool enableAutoMove = true;
    [SerializeField]
    protected float localSpeedModifier = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (enableAutoMove)
            transform.position += Vector3.left * (GameManager.GetSpeed()*localSpeedModifier) * Time.deltaTime;
    }
}
