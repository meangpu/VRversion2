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

    void Start()
    {
        resetTimer();
    }

    void Update()
    {
        if (startCountdown)
        {     
            if (_timeNow > 0)
            {
                _timeNow -= Time.deltaTime;
                DisplayTime(_timeNow);
            }
            else
            {
                // time up game over
            }
        }
    }

    void resetTimer()
    {
        _timeNow = timeValue;
        DisplayTime(_timeNow);
    }

    void DisplayTime(float timeSec)
    {
        if (timeSec <= 0)
        {
            timeSec = 0;
        }
        float min = Mathf.FloorToInt(timeSec / 60);
        float sec = Mathf.FloorToInt(timeSec % 60);
        textTime.SetText(string.Format("{0:00}:{1:00}", min, sec));
    }


}