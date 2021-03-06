using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    private float _timeNow;
    [SerializeField] TMP_Text textTime;
    public bool startCountdown;
    public bool BrainLess;

    private void Awake() 
    {
        GameManager.OnGameStateChange += ListenValueFromGameManager;
    }

    private void OnDestroy() 
    {
        GameManager.OnGameStateChange -= ListenValueFromGameManager;
    }

    void ListenValueFromGameManager(GameState state)
    {
        if (state != GameState.Playing && state != GameState.Losegame && state != GameState.Wingame)
        {
            return;
        }
        else
        {
            if (state == GameState.Playing)
            {
                startCountdown = true;
            }
            else if (state == GameState.Wingame)
            {
                startCountdown = false;
                SendTimeBackToScoreGameMnager();
            }
        }
    }

    void Start()
    {
        timeValue = GameManager.Instance.totalTime;
        resetTimer();
    }

    void Update()
    {
        if (startCountdown)
        {     
            if (_timeNow <= 0)
            {
                GameManager.Instance.UpdateGameState(GameState.Losegame);
                startCountdown = false;
            }
            else
            {
                _timeNow -= Time.deltaTime;
                DisplayTime(_timeNow);
            }

        }
    }

    public void subtractTime(float value)
    {
        _timeNow -= value;
        if(_timeNow <= 0)
        {
            _timeNow = 0;
        }
    }


    public void SendTimeBackToScoreGameMnager()
    {
        if(!BrainLess)
        {
            GameManager.Instance.DoWingame((int)(_timeNow*100));
        }
    }

    public void resetTimer()
    {
        _timeNow = timeValue;
        DisplayTime(_timeNow);
    }

    void DisplayTime(float timeSec)
    {
        if (timeSec <= 0)
        {
            timeSec = 0;
            textTime.SetText("00:00");
        }
        float min = Mathf.FloorToInt(timeSec / 60);
        float sec = Mathf.FloorToInt(timeSec % 60);
        textTime.SetText(string.Format("{0:00}:{1:00}", min, sec));
    }


}
