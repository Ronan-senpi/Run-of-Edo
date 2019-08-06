using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerRangeController : PlayerFollower
{
    protected Collider2D collider;
    protected override void Awake()
    {
        base.Awake();
        collider = GetComponent<Collider2D>();
    }
    // OnTriggerStay2D is called once per frame for every Collider2D other that is touching the trigger (2D physics only)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Shot")
        {

            float distance = collider.Distance(collision).distance;
            collision.transform.parent.GetComponent<ShotController>().LocalSpeedModifier(distance);
        }
    }
}
