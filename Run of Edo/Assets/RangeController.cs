using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    [SerializeField]
    float minScal = .2f;
    [SerializeField]
    float reduceScaleValue= .2f;
    [SerializeField]
    float cooldown= 1f;
    Transform player;
    Vector3 originalScale;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        originalScale = transform.localScale;
    }
    private void Update()
    {
        transform.position = player.position;
        if (Input.GetButtonDown("Fire1"))
        {
            if (transform.localScale.x > .2f)
            {
                transform.localScale -= new Vector3(reduceScaleValue, reduceScaleValue);
            }
        }
        if (transform.localScale.x < originalScale.x)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, cooldown * Time.deltaTime);
        }
    }


}
