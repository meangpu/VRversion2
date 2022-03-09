using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;
using TMPro;

public enum GameState
{
    Waiting,
    Playing,
    Wingame,
    Losegame,
    Pause
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChange;
    public float totalTime = 90; 
    [SerializeField] TMP_Text scoreWinText;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] ScoreBrain scoreBoardBrain;
    [Header("Lock Player")]
    [SerializeField] TeleportController teleScpt;
    [SerializeField] ContinuousMovement ConScpt;
    [SerializeField] SnapTurnProviderBase snapTurnScpt;
    [SerializeField] ToolStatusManager toolManagerScpt;




    public GameState state;
    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        UpdateGameState(GameState.Waiting);
    }

 
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Waiting:
                break;
            case GameState.Playing:
                break;
            case GameState.Wingame:
                break;
            case GameState.Losegame:
                DoLoseGame();
                break;
            case GameState.Pause:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
       }

       OnGameStateChange?.Invoke(newState);  // PREVENT NULL ERROR 

    }

    public void StartGameFromButton()
    {
        UpdateGameState(GameState.Playing);
        AudioManager.instance.StopAllSound();
        AudioManager.instance.Play("level1");
        LockPlayer();
        unlockTools();
    }

    public void DoWingame(int score)
    {
        winPanel.SetActive(true);
        scoreWinText.SetText(score.ToString());
        AudioManager.instance.StopAllSound();
        AudioManager.instance.Play("BombButtonRight");
        AudioManager.instance.Play("Wining");
        scoreBoardBrain.AddNewSave(System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), score);
    }

    public void DoLoseGame()
    {
        losePanel.SetActive(true);
        AudioManager.instance.StopAllSound();
        AudioManager.instance.Play("Lose");
    }

    public void LockPlayer()
    {
        teleScpt.enabled = false;
        ConScpt.enabled = false;
        snapTurnScpt.enabled = false;
    }

    public void unlockTools()
    {
        toolManagerScpt.doUnlockAllToolsAfterStart();
    }

}

