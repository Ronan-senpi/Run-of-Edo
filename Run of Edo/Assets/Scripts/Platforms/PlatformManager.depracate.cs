using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManagerDepracate : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] platforms;
    protected GameObject top;
    protected GameObject middle;
    protected GameObject buttom;

    protected string lastType;
    protected int nbCreatedPlatform = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePlatform()
    {
        if (nbCreatedPlatform < 3)
        {
            //int randPlatformType 
        }
    }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            SetPlatformsSpawner(transform.GetChild(i));
        }
    }

    protected void SetPlatformsSpawner(Transform transform)
    {
        switch (transform.name)
        {
            case "Top":
                this.top = transform.gameObject;
                break;
            case "Middle":
                this.middle = transform.gameObject;
                break;
            case "Bottom":
                this.buttom = transform.gameObject;
                break;
            default:
                break;
        }
    }
}
