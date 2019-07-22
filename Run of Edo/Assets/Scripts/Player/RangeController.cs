﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class RangeController : BaseController
{
    [SerializeField]
    protected float minScal = .2f;
    [SerializeField]
    protected float reduceScaleValue = .2f;
    [SerializeField]
    protected float cooldown = 1.5f;
    [SerializeField]
    protected float rangeModifier = 09f;

    protected Transform tPlayer;
    protected PlayerController playerController;
    protected Vector3 originalScale;

    protected override void Awake()
    {
        base.Awake();
        tPlayer = GameObject.Find("Player").transform;
        playerController = tPlayer.GetComponent<PlayerController>();
        originalScale = transform.localScale;
    }
    protected void Update()
    {
        transform.position = tPlayer.position;
        if (!playerController.IsDead && GameManager.IsStart)
        {
            if (Input.GetButtonDown("Fire1") && transform.localScale.x > minScal)
                transform.localScale -= new Vector3(reduceScaleValue, reduceScaleValue);
            RangeRecover();
        }
    }

    // OnTriggerStay2D is called once per frame for every Collider2D other that is touching the trigger (2D physics only)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Fire1") && !playerController.IsDead)
            if (collision.transform.tag == "Shot")
            {
                collision.transform.GetComponent<ShotBody>().ShotDestroy();
            }
    }

    #region Custom stuff

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
    #endregion
}
