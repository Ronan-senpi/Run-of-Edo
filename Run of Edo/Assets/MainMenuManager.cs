using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Base
{
    [SerializeField]
    protected Animator crossFadeAnimator;
    [SerializeField]
    protected float animationDuration = 1;

    AudioManager am;

    protected virtual void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        am = FindObjectOfType<AudioManager>();

    }
    public void PlayGame()
    {
        StartCoroutine(LoadScene(1));
    }

    private IEnumerator LoadScene(int idScene, float awaitBeforeAnimation = 0)
    {
        yield return new WaitForSeconds(awaitBeforeAnimation);

        //Play annimation
        crossFadeAnimator.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(animationDuration);

        //Load
        SceneManager.LoadScene(idScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        am.StopAll();
        am.Play("PauseIn");
        GameManager.PauseGame();
    }

    public void ResumeGame()
    {
        am.Play("PauseOut");
        GameManager.ResumeGame();
    }

    public void EndGame()
    {
        StartCoroutine(LoadScene(0,1));
    }
}
