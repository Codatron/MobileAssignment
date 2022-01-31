using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public List<SaveData> highScoreEntries = new List<SaveData>();

    private SaveData saveData;

    // Start is called before the first frame update
    void Start()
    {
        saveData = new SaveData();
        
        AddNewScore("bop", 2899);
        AddNewScore("fhty", 953);
        AddNewScore("bballinop", 17);
        AddNewScore("grout", 648);
        AddNewScore("mona", 884);
    }

    // Update is called once per frame
    void UpdateHighScoreDisplay()
    {
        highScoreEntries.Sort((SaveData x, SaveData y) => y.HighScore.CompareTo(x.HighScore));

        
    }

    void AddNewScore(string entryName, int entryScore)
    {
        highScoreEntries.Add(new SaveData { NameSingleP1 = entryName, HighScore = entryScore });
    }
}
