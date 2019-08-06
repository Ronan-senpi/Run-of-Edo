using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class RangeController : PlayerFollower
{
    [SerializeField]
    protected float minScal = .2f;
    [SerializeField]
    protected float reduceScaleValue = .2f;
    [SerializeField]
    protected float cooldown = 1.5f;
    [SerializeField]
    protected float rangeModifier = 09f;
    
    protected PlayerController playerController;
    protected Vector3 originalScale;
    

    protected override void Awake()
    {
        base.Awake();
        playerController = tPlayer.GetComponent<PlayerController>();
        originalScale = transform.localScale;
    }
    protected override void Update()
    {
        base.Update();
        transform.position = tPlayer.position;
        if (!playerController.IsDead && GameManager.IsStart)
        {
            RangeReducer(reduceScaleValue);
            RangeRecover();
        }
    }
    protected void RangeReducer(float modifier)
    {
        if (Input.GetButtonDown("Fire1") && transform.localScale.x > minScal)
            transform.localScale -= new Vector3(modifier, modifier);
    }
    // OnTriggerStay2D is called once per frame for every Collider2D other that is touching the trigger (2D physics only)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((Input.GetButtonDown("Fire1") && !playerController.IsDead) || GameManager.BonusManager.IsAutoRange)
            if (collision.transform.tag == "Shot")
            {
                if (GameManager.BonusManager.IsAutoRange)
                {
                    RangeReducer(reduceScaleValue * GameManager.BonusManager.GetAutoRangeModifier());
                }
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

    public IEnumerator RangeUp(float duration, float modifier)
    {
        Vector3 originalScale = this.originalScale;
        this.originalScale *= modifier;
        float minScal = this.minScal;
        this.minScal *= modifier;
        float reduceScaleValue = this.reduceScaleValue;
        this.reduceScaleValue *= modifier;
        float cooldown = this.cooldown;
        this.cooldown = modifier;
        float rangeModifier = this.rangeModifier;
        this.rangeModifier *= modifier;
        transform.localScale = this.originalScale;

        yield return new WaitForSeconds(duration);
        this.originalScale = originalScale;
        this.minScal = minScal;
        this.reduceScaleValue = reduceScaleValue;
        this.cooldown = cooldown;
        this.rangeModifier = rangeModifier;
        transform.localScale = this.originalScale;
        GameManager.BonusManager.IsAutoRange = false;
    }
    #endregion
}
