using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;
    private void Awake() 
    {
        Instance = this;
    }
}


public enum GameState
{
    Mainmenu,
    Playing,
    Wingame,
    Losegame
}