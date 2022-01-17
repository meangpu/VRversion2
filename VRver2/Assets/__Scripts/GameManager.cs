using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState
{
    Mainmenu,
    Playing,
    Wingame,
    Losegame,
    Pause
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChange;

    public GameState state;
    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Mainmenu:
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

}

