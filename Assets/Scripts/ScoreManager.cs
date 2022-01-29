using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text updateMouseClicks;
    public TMP_Text finalMouseClicks;
    public TMP_Text finalItemsFound;
    public int totalItems;
    
    private int totalMouseClicks = 0;
    private int totalItemsFound;



    public int AddMouseClicks(int mouseClicks)
    {
        // When totalMouseClicks is placed as an argument in FinalMouseClicksDisplay, a wacky number is displayed. Why?
        totalMouseClicks += mouseClicks;  
        UpdateMouseClicksDisplay(mouseClicks);
        FinalMouseClicksDisplay(mouseClicks);
        return totalMouseClicks;
    }
    public int AddItemsFound(int itemsToAdd)
    {
        totalItems -= itemsToAdd;
        totalItemsFound += itemsToAdd;
        UpdateItemsRemainingDisplay(totalItems);
        FinalItemsFoundDisplay(totalItemsFound);
        return totalItemsFound;
    }

    public void UpdateItemsRemainingDisplay(int items)
    {
        scoreText.text = string.Format("Items Remaining: {0:0}", items);
    }

    public void UpdateMouseClicksDisplay(int mouseClicks)
    {
        updateMouseClicks.text = string.Format("Clicks: {0:0}", mouseClicks);
    }

    public void FinalMouseClicksDisplay(int mouseClicks)
    {
        finalMouseClicks.text = string.Format("You found all of the items in {0:0} attempts.", mouseClicks);
    }
    public void FinalItemsFoundDisplay(int items)
    {
        finalItemsFound.text = string.Format("You found {0:0} items!", items);
        //SaveManager.Instance.SaveHighScore(items);
    }
}
