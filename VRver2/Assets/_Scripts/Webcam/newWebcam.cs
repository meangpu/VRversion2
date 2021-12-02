using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newWebcam : MonoBehaviour
{
    public RawImage rawImage;
    [SerializeField] Material colorMat;

    void Start()
    {
        openCam();
    }

    public void openCam()
    {
        WebCamTexture webcamtex = new WebCamTexture();
        colorMat.SetTexture("_MainTex", webcamtex);
        rawImage.texture = webcamtex;
        rawImage.material.mainTexture = webcamtex;
        webcamtex.Play();
    }


}
