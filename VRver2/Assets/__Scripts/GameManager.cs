using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public int score; 

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

    }

}

