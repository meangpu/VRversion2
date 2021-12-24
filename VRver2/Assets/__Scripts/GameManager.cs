using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
            default:
                Debug.Log("case bug");
       }
    }

}



public enum GameState
{
    Mainmenu,
    Playing,
    Wingame,
    Losegame
}