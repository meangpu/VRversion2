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
    public bool statusLeft;
    [Header("Cam")]
    [SerializeField] Image bgCam;
    [SerializeField] TMP_Text wordCam;
    public bool statusCam;
    [Header("Right")]
    [SerializeField] Image bgRight;
    [SerializeField] TMP_Text wordRight;
    public bool statusRight;

    [Header("Right")]
    [SerializeField] Button startGameBtn;
    [Header("CamSetting")]
    [SerializeField] Transform CamToolGameObj;
    [SerializeField] Transform CamPosTarget;


    void Start()
    {
        updateAllStatus();
    }

    public void updateAllStatus()
    {
        UpdateElement(bgLeft, wordLeft, statusLeft);
        UpdateElement(bgCam, wordCam, statusCam);
        UpdateElement(bgRight, wordRight, statusRight);
        checkIfCanStart();
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

    public void checkWithTagName(GameObject colliderTool, string tagName)
    {
        if (colliderTool.tag != tagName)
        {
            return;
        }
        else
        {
            if(tagName == "LeftLa")
            {
                statusLeft = true;
            }
            if(tagName == "RightLa")
            {
                statusRight = true;
            }
            if(tagName == "CamTool")
            {   
                statusCam = true;
                CamToolGameObj.localPosition = CamPosTarget.position;
                CamToolGameObj.localRotation = CamPosTarget.rotation;
            }
            updateAllStatus();
        }
    }

    public void checkIfCanStart()
    {
        if (statusLeft && statusCam && statusRight)
        {
            startGameBtn.interactable = true;
        }
        else
        {
            startGameBtn.interactable = false;
        }
    }


}
