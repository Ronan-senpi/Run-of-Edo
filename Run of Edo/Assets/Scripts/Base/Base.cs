using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    protected GameManager GameManager { get; set; }

    // Awake is called when the script instance is being loaded
    protected virtual void Awake()
    {
        GameObject tmpManager = GameObject.Find("GameManager");
        if (tmpManager != null)
        {
            GameManager = tmpManager.GetComponent<GameManager>();
        }
        else
        {
            Debug.Log("<color=Red>Aucun " + name + " n'a pu être trouver dans la scene</color>");
            Debug.Break();
        }
    }
}
