using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadCam : MonoBehaviour
{
    [SerializeField] Material meangpuMat;

    private void Start() 
    {
        openQuadCam();
    }

    public void openQuadCam()
    {
        WebCamTexture webcamtex = new WebCamTexture();
        Renderer render = GetComponent<Renderer>();
        render.material.mainTexture = webcamtex;
        meangpuMat.SetTexture("_MainTex", webcamtex);
        // rawImage.texture = webcamtex;
        // rawImage.material.mainTexture = webcamtex;
        webcamtex.Play();
    }
}
