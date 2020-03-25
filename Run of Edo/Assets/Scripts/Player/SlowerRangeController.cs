using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerRangeController : PlayerFollower
{
    protected CircleCollider2D circleCollider;
    protected override void Awake()
    {
        base.Awake();
        circleCollider = GetComponent<CircleCollider2D>();
    }
    // OnTriggerStay2D is called once per frame for every Collider2D other that is touching the trigger (2D physics only)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Shot")
        {
            float distance = circleCollider.Distance(collision).distance;
            float NormalizeDistance = Mathf.Abs(distance / circleCollider.radius);
            collision.transform.parent.GetComponent<ShotController>().LocalSpeedModifier(NormalizeDistance);
        }
    }
}
