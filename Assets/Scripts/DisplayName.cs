using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayName : MonoBehaviour
{
    public TMP_Text display;

    void Start()
    {
        display.text = "Squirrel 1: " + SaveManager.Instance.saveData.NameSingleP1;
    }
}
