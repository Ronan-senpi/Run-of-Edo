using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    [SerializeField]
    protected float minScal = .2f;
    [SerializeField]
    protected float reduceScaleValue = .2f;
    [SerializeField]
    protected float cooldown = 1.5f;
    [SerializeField]
    protected float rangeModifier = 09f;
    protected bool shooting { get { return Input.GetButtonDown("Fire1") && !playerController.IsDead; } }

    protected Transform tPlayer;
    protected PlayerController playerController;
    protected Vector3 originalScale;
    private void Awake()
    {
        tPlayer = GameObject.Find("Player").transform;
        playerController = tPlayer.GetComponent<PlayerController>();
        originalScale = transform.localScale;
    }
    private void Update()
    {
        transform.position = tPlayer.position;
        if (shooting)
        {
            if (transform.localScale.x > minScal)
            {
                transform.localScale -= new Vector3(reduceScaleValue, reduceScaleValue);
            }
        }
        RangeRecover();
    }

    private void RangeRecover()
    {
        Vector3 vec;
        if (transform.localScale.x <= originalScale.x)
        {
            float localRangeModifer = Random.Range(-rangeModifier, 0);
            vec = new Vector3(localRangeModifer, localRangeModifer, originalScale.z);
        }
        else
        {
            float localRangeModifer = Random.Range(0, rangeModifier);
            vec = new Vector3(localRangeModifer, localRangeModifer, originalScale.z);
        }
        transform.localScale = Vector3.MoveTowards(transform.localScale, originalScale + vec, cooldown * Time.deltaTime);

    }

    // OnTriggerStay2D is called once per frame for every Collider2D other that is touching the trigger (2D physics only)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Shot" && shooting)
        {
            collision.transform.GetComponent<ShotBody>().ShotDestroy();
        }
    }

}
