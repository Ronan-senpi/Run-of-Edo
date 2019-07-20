using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShotBody : MonoBehaviour, Destroyable, Shot
{
    public virtual void ExitDestroy()
    {
        Destroy(transform.parent.gameObject);
    }

    public virtual void ShotDestroy()
    {
        ExitDestroy();
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .1f);
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
