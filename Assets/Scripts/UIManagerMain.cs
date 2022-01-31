using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerMain : MonoBehaviour
{
    public Canvas canvasMenu;
    public Canvas canvasGameMode;
    public Canvas canvasSettingsSingle;
    public Canvas canvasSettingsMultiplayer;
    public Canvas canvasHighScore;
    public TMP_InputField inputSingleP1;
    public TMP_InputField inputMultiP1;
    public TMP_InputField inputMultiP2;

    //public TMP_InputField inputMultiplayerP1;
    //public TMP_InputField inputMultiplayerP2;

    void Start()
    {
        canvasGameMode.enabled = false;
        canvasSettingsSingle.enabled = false;
        canvasSettingsMultiplayer.enabled = false;
        canvasHighScore.enabled = false;
    }

    // Buttons in Menu
    public void NewGame()
    {
        canvasGameMode.enabled = true;
        canvasMenu.enabled = false;
    }

    public void SinglePlayerMode()
    {
        canvasSettingsSingle.enabled = true;
        canvasGameMode.enabled = false;
    }

    public void MultiplayerMode()
    {
        canvasSettingsMultiplayer.enabled = true;
        canvasGameMode.enabled = false;
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
    public void SaveSingleP1()
    {
        SaveManager.Instance.SaveNameSingleP1(inputSingleP1.text);
    }

    public void SaveMultiP1()
    {
        SaveManager.Instance.SaveNameMultiP1(inputMultiP1.text);
    }

    public void SaveMultiP2()
    {
        SaveManager.Instance.SaveNameMultiP2(inputMultiP2.text);
    }
}
