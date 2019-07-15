﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBody : MonoBehaviour, Destroyable
{
    public void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerController>().Dead();
        }
    }

}
