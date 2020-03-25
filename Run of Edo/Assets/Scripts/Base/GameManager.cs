using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IManager
{

    //TODO : REMOVE FOR RELEASE !!
    [SerializeField]
    protected bool forceStart = false;

    [Header("Game speed")]
    [SerializeField]
    [Range(0,50)]
    protected float gameSpeed = 10;

    [SerializeField]
    protected float maxGameSpeed = 30;

    [SerializeField]
    protected float gameSpeedIncrement = 0.5f;

    [SerializeField]
    protected float IncrementGameSpeedEverySeconds = 10;

    protected float period = 0.0f;
    protected bool isMaxGameSpeed = false;

    [Header("Menus")]

    [SerializeField]
    protected MainMenuManager menuManager;

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
    public BonusManager BonusManager { get { return bonusManager; } }

    [SerializeField]
    protected AudioManager audioManager;
    public AudioManager AudioManager { get { return audioManager; } }

    public float Score { get; protected set; }
    protected float StartSince = 0;

    protected float gameSpeedOld = 0;
    public bool IsStart { get { return gameSpeed > 0; } }

    public float FormatedScore { get; set; }

    private void Awake()
    {
        gameSpeedOld = gameSpeed;
        //StopGame();
    }

    // Use this for initialization
    void Start()
    {
        Score = 0f;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsStart && (period > IncrementGameSpeedEverySeconds && !isMaxGameSpeed))
        {
            SpeedUpGame();
            period = 0.0f;
        }
        period += Time.deltaTime;

        if (gameSpeed >= 1)
        {
            Score += Time.deltaTime / gameSpeed*3;
        }
        //TODO : REMOVE FOR RELEASE !!
        if (forceStart && !Player.Controller.IsDead)
        {
            StartGame();
        }
    }
    
    
    protected void SpeedUpGame()
    {
        if (gameSpeed + gameSpeedIncrement > maxGameSpeed)
        {
            gameSpeed = maxGameSpeed;
            isMaxGameSpeed = true;
        }
        else
        {
            gameSpeed += gameSpeedIncrement;
            isMaxGameSpeed = false;
        }
    }

    public void EndGame()
    {
        StopGame();
        menuManager.EndGame();
    }

    public void StopGame()
    {
        //Pas fou mais fait le taff pour le moment
        gameSpeed = 0;
    }
    public void PauseGame()
    {
        playerManager.Controller.StopAnimation();
        playerManager.Controller.Freeze();
        
        StopGame();
    }

    public void ResumeGame()
    {
        StartGame();
        playerManager.Controller.Unfreeze();
        playerManager.Controller.StartAnimation();
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
        if (IsStart)
        {
            //Attends le nombre de seconde passer en paramètre 
            yield return new WaitForSeconds(slowdownTime);

            gameSpeed = MaxSpeedOrigin;
            Player.Controller.Hurt();
        }
    }

    // Bonus

    /// <summary>
    /// Augmente la vitesse de défilement du jeux,
    /// le player est invincible
    /// </summary>
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

    public void AutoRange()
    {
        bonusManager.IsAutoRange = true;
        StartCoroutine(Player.Range.RangeUp(bonusManager.GetAutoRangeDuration(), bonusManager.GetAutoRangeModifier()));
    }
}
