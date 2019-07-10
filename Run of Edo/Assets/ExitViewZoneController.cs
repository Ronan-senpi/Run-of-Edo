using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitViewZoneController : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        Destroyable dest = collision.GetComponent<Destroyable>();
        if (dest != null)
        {
            dest.Destroy();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
