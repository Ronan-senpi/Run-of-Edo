using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    [SerializeField]
    float minScal = .2f;
    [SerializeField]
    float reduceScaleValue = .2f;
    [SerializeField]
    float cooldown = 1f;

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
        if (transform.localScale.x < originalScale.x)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, cooldown * Time.deltaTime);
        }
    }


    // OnTriggerStay2D is called once per frame for every Collider2D other that is touching the trigger (2D physics only)
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name);

        if (collision.transform.tag == "Shot" && shooting)
        {
            collision.transform.GetComponent<ShotBody>().Destroy();
        }
    }

}
