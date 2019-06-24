using Platform;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    protected PlatformTypes[] platformTypes;
    private float viewZone;

    public bool IsOutView
    {
        get
        {
            return true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        viewZone = (Camera.main.orthographicSize * Screen.width) / Screen.height;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsOutView)
        {

        }
    }

    private void GenerateNewPlatform()
    {

    }
}
