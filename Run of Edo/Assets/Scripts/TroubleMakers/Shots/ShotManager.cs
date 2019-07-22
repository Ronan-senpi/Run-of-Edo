using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : Base, IManager
{
    [SerializeField]
    protected GameObject[] shots;
    [SerializeField]
    protected float MinTimeShoot = 3;
    [SerializeField]
    protected float MaxTimeShoot = 10;
    protected PlayerController playerController;

    protected override void Awake()
    {
        base.Awake();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(MinTimeShoot, MaxTimeShoot));
        Vector3 startPositionShot = playerController.transform.position;
        startPositionShot.x = transform.position.x;
        if (GameManager.IsStart)
        {
            GameObject shot = Instantiate(shots[Random.Range(0, shots.Length)], startPositionShot, Quaternion.identity);
            shot.transform.parent = transform;
        }
        StartCoroutine(Shoot());
    }

    public void Clear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
