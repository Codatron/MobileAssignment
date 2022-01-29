using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text timeDisplay;
    public float timeRemaining;
    public bool isGameOver = false;
    public bool isPaused = false;

    public int tries = 0;
    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        Pausegame();
        GameOver();
    }
    private void Pausegame()
    {
        if (isPaused)
        {
            Time.timeScale = 0.0f;
            Debug.Log("Game is paused!");
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    private void GameOver()
    {
        //TODO: Change magic number
        if (scoreManager.totalItems == 0 || tries == 15)
        {
            isGameOver = true;
            Time.timeScale = 0.0f;
        }
    }

    private void TimerCountdown()
    {
        if (timeRemaining > 0.0f)
        {
            timeDisplay.text = string.Format("Time: {0:0.00}", timeRemaining);
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining <= 0.0f)
        {
            timeDisplay.text = string.Format("Time: {0:0.00}", 0.00);
            isGameOver = true;
            Time.timeScale = 0.0f;
        }
    }

}
