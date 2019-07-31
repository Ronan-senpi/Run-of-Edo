using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitViewZoneController : Base
{
    PlatformManager platformManager;
    // Awake is called when the script instance is being loaded
    protected override void Awake()
    {
        base.Awake();
        platformManager = GameManager.PlatformManager;
    }

    // OnTriggerExit2D is called when the Collider2D other has stopped touching the trigger (2D physics only)
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroyable dest = collision.GetComponent<Destroyable>();
        if (dest != null)
        {
            dest.ExitDestroy();
        }
        else if (collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<PlayerController>().Dead();
        }
        else
        {
            // Destroy(collision.gameObject);
        }
    }

}
