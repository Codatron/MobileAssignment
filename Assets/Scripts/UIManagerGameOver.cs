using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManagerGameOver : MonoBehaviour
{
    public Canvas canvasGameOver;
    public Canvas canvasPauseMenu;
    public UnityEngine.GameObject buttonPause;

    private GameManager gameManager;
   
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        canvasGameOver.enabled = false;
        canvasPauseMenu.enabled = false;
    }

    void Update()
    {
        if (gameManager.isGameOver)
        {
            canvasGameOver.enabled = true;
        }

        if (gameManager.isPaused)
        {
            canvasPauseMenu.enabled = true;
        }
    }

    public void Pause()
    {
        gameManager.isPaused = true;
        canvasPauseMenu.enabled = true;
        buttonPause.SetActive(false);
    }

    public void Resume()
    {
        gameManager.isPaused = false;
        canvasPauseMenu.enabled = false;
        buttonPause.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
