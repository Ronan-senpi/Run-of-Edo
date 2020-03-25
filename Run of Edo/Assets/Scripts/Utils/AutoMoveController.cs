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

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        if (GameManager != null)
            if (enableAutoMove && GameManager.IsStart)
                transform.position += Vector3.left * (GameManager.GetSpeed() * localSpeedModifier) * Time.deltaTime;
        //Debug.Log(name + " : " + (GameManager.GetSpeed() * localSpeedModifier));
    }
}
