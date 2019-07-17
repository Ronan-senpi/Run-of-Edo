using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBody : MonoBehaviour, Destroyable, Shot
{
    public virtual void ExitDestroy()
    {
        Destroy(transform.parent.gameObject);
    }

    public virtual void ShotDestroy()
    {
        ExitDestroy();
    }



    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerController>().Dead();
            ExitDestroy();
        }
    }

}
