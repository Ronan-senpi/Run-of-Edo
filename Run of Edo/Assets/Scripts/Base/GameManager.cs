using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IManager
{

    //TODO : REMOVE FOR RELEASE !!
    [SerializeField]
    protected bool forceStart = false;
    [SerializeField]
    protected float gameSpeed = 15;

    [Header("Managers")]
    [SerializeField]
    protected PlayerManager playerManager;
    public PlayerManager Player { get { return playerManager; } }

    [SerializeField]
    protected PlatformManager platformManager;
    public PlatformManager PlatformManager { get { return platformManager; } }

    [SerializeField]
    protected ShotManager shotManager;

    [SerializeField]
    protected BonusManager bonusManager;
    
    protected float StartSince = 0;

    protected float gameSpeedOld = 0;
    public bool IsStart { get { return gameSpeed > 0; } }



    private void Awake()
    {
        gameSpeedOld = gameSpeed;
        //StopGame();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //TODO : REMOVE FOR RELEASE !!
        if (forceStart && !Player.Controller.IsDead)
        {
            StartGame();
        }
    }

    public void StopGame()
    {
        //Pas fou mais fait le taff pour le moment
        gameSpeed = 0;
    }

    public void StartGame()
    {
        gameSpeed = gameSpeedOld;
        Debug.Log("IsStart : " + IsStart);
    }

    public float GetSpeed()
    {
        return gameSpeed;
    }

    public void SlowDown(float speedDivider, float slowdownTime)
    {
        if (Player.Controller.IsHurt)
        {
            Player.Controller.Dead();
        }
        else
        {
            float MaxSpeedOrigin = gameSpeed;
            gameSpeed /= speedDivider;
            Player.Controller.Hurt();
            //Lance une fonction coroutine
            StartCoroutine(RecoverySpeed(slowdownTime, MaxSpeedOrigin));
            Debug.Log("Aïe !! je vais a : " + gameSpeed + " au lieux de " + MaxSpeedOrigin);
        }
    }
    IEnumerator RecoverySpeed(float slowdownTime, float MaxSpeedOrigin)
    {
        //Attends le nombre de seconde passer en paramètre 
        yield return new WaitForSeconds(slowdownTime);
        gameSpeed = MaxSpeedOrigin;
        Player.Controller.Hurt();
    }

   // Bonus

   /// <summary>
   /// Augmente la vitesse de défilement du jeux,
   /// le player est invincible
   /// </summary>
    public void SpeedUp()
    {
        StartCoroutine(CSpeedUp());
    }
    protected IEnumerator CSpeedUp()
    {
        gameSpeed = gameSpeed * bonusManager.GetSpeedUpModifier();
        Player.Controller.SpeedUp = true;
        yield return new WaitForSeconds(bonusManager.GetSpeedUpDuration());
        platformManager.ReloadPlatform(Player.Controller.transform.position);
        shotManager.Clear();
        Player.Controller.SpeedUp = false;
        gameSpeed = gameSpeedOld;
    }

    public void RangeUp()
    {
        StartCoroutine(Player.Range.RangeUp(bonusManager.GetRangeUpDuration(), bonusManager.GetRangepModifier()));
    }

}
