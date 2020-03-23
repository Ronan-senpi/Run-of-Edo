using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class ClaudsManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] clauds;

    [SerializeField]
    protected GameObject p1;
    [SerializeField]
    protected GameObject p2;

    protected float minAltitude = 0;
    protected float MaxAltitude = 0;

    private void Awake()
    {
        minAltitude = p1.transform.position.y;
        MaxAltitude = p2.transform.position.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GenerateClaud();
    }

    void GenerateClaud()
    {
        float x;
        GameObject target;
        if (Random.Range(0, 1) == 0)
        {
            x = p2.transform.position.x;
            target = p1;
        }
        else
        {
            x = p1.transform.position.x;
            target = p2;

        }
        Vector3 position = GneratePosition(x);
        GameObject claud = Instantiate(clauds[RandIndex()], position, Quaternion.identity);
        claud.transform.parent = transform;
        ClaudsController cc = claud.GetComponent<ClaudsController>();
        cc.target = target.transform.position;//new Vector3(target.transform.position.x, position.y, position.z);
    }

    protected Vector3 GneratePosition(float x)
    {
        float y = (float)Math.Round(Random.Range(minAltitude, MaxAltitude), 1);
        return new Vector3(x, y, 100);
    }


    protected int RandIndex()
    {
        return Random.Range(0, clauds.Length);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
