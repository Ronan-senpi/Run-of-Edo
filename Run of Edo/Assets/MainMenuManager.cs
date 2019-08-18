using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : Base
{
    [SerializeField]
    protected GameObject EndGameMenu;

    protected virtual void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
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
        GameManager.StopGame();
    }

    public void ResumeGame()
    {
        GameManager.StartGame();
    }

    public void EndGame()
    {
        EndGameMenu.SetActive(true);
    }
}
