using UnityEngine;
// using UnityEditor;
using System;

[System.Serializable]
class skybox
{
    public string skyName;
    public Material skyMat;
    // public LightingSettings lightSetting;
    public GameObject directionalLight;

    public void doChangeSky()
    {
        RenderSettings.skybox = skyMat;
        // Lightmapping.lightingSettings = lightSetting;
        GameObject[] allDirect = GameObject.FindGameObjectsWithTag("DirectLight");
        foreach (GameObject _light in allDirect)
        {
            _light.SetActive(false);
        }

        directionalLight.SetActive(true);
    }
}



public class skyChanger : MonoBehaviour
{
    [SerializeField] skybox[] allSky;

    public void changeSkyWithName(string name)
    {
        skybox s = Array.Find(allSky, s => s.skyName == name);
        if(s==null)
        {
            return;
        }
        s.doChangeSky();
    }

    [ContextMenu("AAA")]
    public void www() 
    {
        changeSkyWithName("1");
    }
  
}
