using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    protected GameManager GameManager { get; set; }

    protected virtual void Awake()
    {
        GameManager = FindManager<GameManager>("GameManager");
    }
    public static T FindManager<T>(string name) where T : class, IManager
    {
        GameObject tmpManager = GameObject.Find(name);
        if (tmpManager != null)
        {
            return tmpManager.GetComponent<T>();
        }
        else
        {
            Debug.Log("<color=Red>Aucun " + name + " n'a pu être trouver dans la scene</color>");
            Debug.Break();
            return null;
        }
    }
}
