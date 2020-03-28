using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShotBody : MonoBehaviour, Destroyable, Shot
{
    AudioManager am;

    [SerializeField]
    protected GameObject hit;
    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }
    public virtual void ExitDestroy()
    {
        Destroy(transform.parent.gameObject);
    }

    public virtual void ShotDestroy(RangeController rangeController)
    {
        GetComponent<Collider2D>().enabled = false;
        CameraShaker.Instance.ShakeOnce(4f, 4f, .25f, .25f);
        am.Play("AttackHit");
        Instantiate(hit, transform.position, Quaternion.identity, rangeController.transform);
        ExitDestroy();
    }



    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerController>().Dead();
            ExitDestroy();
        }
    }

}
