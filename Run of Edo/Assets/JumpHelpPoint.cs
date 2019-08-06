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

        }
    }

    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "PlayerSub")
        {
            ContactPoint2D contact = collision.contacts[0];
            Bounds playerbounds = collision.transform.GetComponent<SpriteRenderer>().bounds;
            float quarterSpriteY = playerbounds.size.y / 3;
            if (contact.point.y <= (collision.transform.position.y - quarterSpriteY))
            {
                Vector3 newPosition = new Vector3(collision.transform.position.x, (transform.parent.transform.position.y + 0.1f + playerbounds.size.y / 2f), collision.transform.position.x);
                collision.transform.position = newPosition;
                Debug.Log("teleportation");
            }

        }
    }
}
