using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpController : BonusController
{

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            GameManager.SpeedUp();
        }
    }

}
 