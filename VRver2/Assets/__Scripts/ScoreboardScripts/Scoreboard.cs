using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private int maxScoreBoardEntries = 5;
    [SerializeField] private Transform highscoreHolderTransform = null;
    [SerializeField] private GameObject scoreboardEntryObject = null;
    [Header("Test")]
    [SerializeField] private string testEntryName = "New Name";
    [SerializeField] private int testEntryScore = 0;
    private string SavePath => $"{Application.persistentDataPath}/highscore.json";

    private void Start(){
        print(SavePath);
        ScoreboardSaveData savedScores = GetSavedScores();
        UpdateUI(savedScores);
        SaveScores(savedScores);
    }

    [ContextMenu("Add Test Entry")] 
    public void AddTestEntry(){
        AddEntry(new ScoreboardEntryData()
        {
            entryName = testEntryName,
            entryScore = testEntryScore
        });
    }       

    public void AddEntry(ScoreboardEntryData scoreboardEntryData)
    {
        ScoreboardSaveData savedScores = GetSavedScores();
        bool scoreAdded = false;
        
        // Check if score is high enough to be added
        for (int i = 0; i < savedScores.highscores.Count; i++)
        {
            if (testEntryScore > savedScores.highscores[i].entryScore)
            {
                savedScores.highscores.Insert(i, scoreboardEntryData);
                scoreAdded = true;
                break;
            }
        }

        if(!scoreAdded && savedScores.highscores.Count < maxScoreBoardEntries)
        {
            savedScores.highscores.Add(scoreboardEntryData);
        }

        if (savedScores.highscores.Count > maxScoreBoardEntries)
        {
            savedScores.highscores.RemoveRange(maxScoreBoardEntries, savedScores.highscores.Count - maxScoreBoardEntries);
        }

        UpdateUI(savedScores);
        SaveScores(savedScores);


    }
 
    private void UpdateUI(ScoreboardSaveData savedScores)
    {
        foreach (Transform child in highscoreHolderTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (ScoreboardEntryData highscore in savedScores.highscores)
        {
            Instantiate(scoreboardEntryObject, highscoreHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(highscore);
        }
    } 

    private ScoreboardSaveData GetSavedScores()
    {
        if (!File.Exists(SavePath))
        {
            File.Create(SavePath).Dispose();
            return new ScoreboardSaveData();
        }
        using (StreamReader stream = new StreamReader(SavePath))
        {
            string json = stream.ReadToEnd();
            return JsonUtility.FromJson<ScoreboardSaveData>(json);
        }

    }

    private void SaveScores(ScoreboardSaveData scoreboardSaveData)
    {
        using (StreamWriter stream = new StreamWriter(SavePath))
        {
            string json = JsonUtility.ToJson(scoreboardSaveData, true);
            stream.Write(json);
        }
    }
     
}
