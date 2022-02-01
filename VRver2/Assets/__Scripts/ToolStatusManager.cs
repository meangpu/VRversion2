using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;


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
    [SerializeField] XRGrabInteractable leftGrabScpt;
    [SerializeField] Rigidbody leftRb;
    [SerializeField] Collider leftCol;
    public bool statusLeft;

    [Header("Cam")]
    [SerializeField] Image bgCam;
    [SerializeField] TMP_Text wordCam;
    [SerializeField] XRGrabInteractable camGrabScpt;
    [SerializeField] Rigidbody camRb;
    [SerializeField] Collider camCol;
    public bool statusCam;

    [Header("Right")]
    [SerializeField] Image bgRight;
    [SerializeField] TMP_Text wordRight;
    [SerializeField] XRGrabInteractable rightGrabScpt;
    [SerializeField] Rigidbody rightRb;
    [SerializeField] Collider rightCol;
    public bool statusRight;

    [Header("start")]
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
                StartCoroutine(doLockTools(leftRb, leftGrabScpt, leftCol));

            }
            if(tagName == "RightLa")
            {
                statusRight = true;
                StartCoroutine(doLockTools(rightRb, rightGrabScpt, rightCol));

            }
            if(tagName == "CamTool")
            {   
                statusCam = true;
                StartCoroutine(doLockTools(camRb, camGrabScpt, camCol));


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


    public IEnumerator doLockTools(Rigidbody _rb, XRGrabInteractable _xrGrab, Collider _col, float wait=0.6f)
    {
        yield return new WaitForSeconds(wait);
        _xrGrab.trackPosition = false;
        _rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        _col.isTrigger = true;
        

    }

}
