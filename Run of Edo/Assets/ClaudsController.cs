using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaudsController : MonoBehaviour
{

    [SerializeField]
    protected float speed = 1f;

    public Vector3 target;

    // Update is called once per frame
    void Update()
    {
        //if (target == null)
        //    return;
        //transform.Translate(new Vector3(target.x, target.y).normalized * speed * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        //if (!isEndGame)
        //{
            if (target != null)
            {
                //Permet le déplacement entre "this.transform.position" (la position actuelle) et "target.position" (la position d'arrivé)
                this.transform.position = Vector3.MoveTowards(this.transform.position, target, this.speed * Time.fixedDeltaTime);

            }
        //}
    }
}
