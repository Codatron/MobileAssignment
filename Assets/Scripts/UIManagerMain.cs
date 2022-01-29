using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerMain : MonoBehaviour
{
    public Canvas canvasMenu;
    public Canvas canvasSettings;
    public Canvas canvasHighScore;
    public TMP_InputField inputName;

    void Start()
    {
        canvasSettings.enabled = false;
        canvasHighScore.enabled = false;
    }

    // Buttons in Menu
    public void NewGame()
    {
        canvasSettings.enabled = true;
        canvasMenu.enabled = false;
    }

    public SaveData LoadGame()
    {
        // Loads progress from a previous game using PlayerPrefs
        //PlayerPrefs.GetString("Name");
        //PlayerPrefs.GetInt("Score");

        string json = PlayerPrefs.GetString("SaveData");
        SaveData loadSaveData = JsonUtility.FromJson<SaveData>(json);

        return loadSaveData;
    }

    public void HighScore()
    {
        // Loads High Score screen
        canvasHighScore.enabled = true;
        canvasMenu.enabled = false;
    }

    public void ReturnToMenu()
    {
        canvasHighScore.enabled = false;
        canvasMenu.enabled = true;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    // Save Button
    public void Save()
    {
        SaveManager.Instance.SaveName(inputName.text);
    }
}
