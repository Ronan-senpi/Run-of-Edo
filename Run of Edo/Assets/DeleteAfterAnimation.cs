using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterAnimation : MonoBehaviour
{
    [SerializeField]
    protected float delay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, this.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

}
