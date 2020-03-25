using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHelpPoint : MonoBehaviour
{
    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "PlayerSub")
        {
            float tmp =   collision.transform.position.y - transform.position.y;
            Debug.Log(tmp);
            this.RescurePlayer(collision.transform, tmp);
        }
    }

    protected bool RescurePlayer(Transform colTransform, float contactPointY)
    {
        Bounds playerbounds = colTransform.GetComponentInChildren<SpriteRenderer>().bounds;
        float quarterSpriteY = playerbounds.size.y / 3;
        if ((colTransform.position.y - transform.position.y) >= quarterSpriteY)
        {
            Vector3 newPosition = new Vector3(colTransform.position.x, (transform.position.y + 0.2f + playerbounds.size.y / 2f), colTransform.position.x);
            colTransform.position = newPosition;
            return true;
        }

        return false;
    }

    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "PlayerSub")
        {
            Debug.Log("hi !");
            ContactPoint2D contact = collision.contacts[0];
            this.RescurePlayer(collision.transform, contact.point.y);
        }
    }
}
