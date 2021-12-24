using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webCam : MonoBehaviour
{
    int currentCamIndex = 0;
    WebCamTexture tex;
    public RawImage display;

    public void openCam()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
            Debug.Log(WebCamTexture.devices);
            if (tex != null)
            {
                stopWebcam();
                StartStopCam();
            }
        }
    }

    public void StartStopCam()
    {
        if (tex != null)
        {
            stopWebcam();
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            tex.Play();
        }

    }

    private void stopWebcam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }
}
