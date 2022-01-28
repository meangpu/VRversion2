using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ToolStatusManager : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] Color greenCol;
    [SerializeField] Color RedCol;
    [SerializeField] string readyWord;
    [SerializeField] string missingWord;

    [Header("Left")]
    [SerializeField] Image bgLeft;
    [SerializeField] TMP_Text wordLeft;
    [SerializeField] bool statusLeft;
    [Header("Cam")]
    [SerializeField] Image bgCam;
    [SerializeField] TMP_Text wordCam;
    [SerializeField] bool statusCam;
    [Header("Right")]
    [SerializeField] Image bgRight;
    [SerializeField] TMP_Text wordRight;
    [SerializeField] bool statusRight;


    void Start()
    {
        updateAllStatus();
    }

    public void updateAllStatus()
    {
        UpdateElement(bgLeft, wordLeft, statusLeft);
        UpdateElement(bgCam, wordCam, statusCam);
        UpdateElement(bgRight, wordRight, statusRight);
    }

    public void UpdateElement(Image _img, TMP_Text _text, bool _status)
    {
        if (_status)
        {
            _img.color = greenCol;
            _text.SetText(readyWord);
        }
        else
        {
            _img.color = RedCol;
            _text.SetText(missingWord);
        }
    }


}
