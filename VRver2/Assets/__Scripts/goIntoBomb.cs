using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goIntoBomb : MonoBehaviour
{
    [SerializeField] Camera mainVRcam;
    [SerializeField] Camera bombCam;

    [ContextMenu("in")]
    public void goIn()
    {
        mainVRcam.enabled = false;
        bombCam.enabled = true;
    }

    [ContextMenu("out")]
    public void goOut()
    {
        mainVRcam.enabled = true;
        bombCam.enabled = false;
    }



}
