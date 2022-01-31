using UnityEngine;
using System.IO;

public class ScoreBrain : MonoBehaviour
{
    [SerializeField] private int maxScoreBoardEntries = 6;
    [SerializeField] string levelName = "level1";
    private string SavePath => $"{Application.persistentDataPath}/{levelName}.json";

    private void Start()
    {
        print(SavePath);
        ScoreboardSaveData savedScores = GetSavedScores();
        SaveScores(savedScores);
    }


    public void AddNewSave(string playerName, int score)
    {
        AddEntry(new ScoreboardEntryData()
        {
            entryName = playerName,
            entryScore = score
        });
    }       

    public void AddEntry(ScoreboardEntryData scoreboardEntryData)
    {
        ScoreboardSaveData savedScores = GetSavedScores();
        bool scoreAdded = false;
        
        // Check if score is high enough to be added
        for (int i = 0; i < savedScores.highscores.Count; i++)
        {
            if (scoreboardEntryData.entryScore > savedScores.highscores[i].entryScore)
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

        SaveScores(savedScores);

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
