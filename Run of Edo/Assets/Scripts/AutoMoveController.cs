using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveController : Base
{
    [SerializeField]
    protected bool enableAutoMove = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enableAutoMove)
            transform.position += Vector3.left * GameManager.GetSpeed() * Time.deltaTime;
    }
}
