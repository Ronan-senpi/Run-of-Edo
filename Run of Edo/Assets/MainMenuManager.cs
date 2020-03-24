using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Base
{
    [SerializeField]
    protected GameObject EndGameMenu;

    AudioManager am;

    protected virtual void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        am = FindObjectOfType<AudioManager>();

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
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
        EndGameMenu.SetActive(true);
    }
}
