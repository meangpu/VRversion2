using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingSlider : MonoBehaviour
{
    [Header("Height")]
    [SerializeField] TMP_Text eyeText;
    [SerializeField] Slider eyeSlider;
    [SerializeField] Transform eyeTrans;
    [SerializeField] Transform headValue;
    [SerializeField] TMP_Text nowHeadText;

    [SerializeField] TMP_Text tableText;
    [SerializeField] Slider tableSlider;

    [Header("Volumn")]
    [SerializeField] TMP_Text masterVolText;
    [SerializeField] Slider masterVolSlider;
    
    [SerializeField] TMP_Text sfxVolText;
    [SerializeField] Slider sfxVolSlider;

    [SerializeField] TMP_Text musicVolText;
    [SerializeField] Slider musicVolSlider;

    private void Start() 
    {
        eyeSlider.onValueChanged.AddListener((v) => 
        {
            eyeText.SetText(v.ToString("0.00"));

        });

        tableSlider.onValueChanged.AddListener((v) => 
        {
            tableText.SetText(v.ToString("0.00"));
        });

        // volumn

        masterVolSlider.onValueChanged.AddListener((v) => 
        {
            masterVolText.SetText(v.ToString("0.00"));
        });

        sfxVolSlider.onValueChanged.AddListener((v) => 
        {
            sfxVolText.SetText(v.ToString("0.00"));
        });

        musicVolSlider.onValueChanged.AddListener((v) => 
        {
            musicVolText.SetText(v.ToString("0.00"));
        });

    }

    public void setEyeLevel()
    {
        Vector3 newH = new Vector3(eyeTrans.position.x, eyeSlider.value, eyeTrans.position.z);
        eyeTrans.position = newH;
    }

    public void getEyeValueNow()
    {
        float nowhead = headValue.transform.position.y;
        nowHeadText.SetText(nowhead.ToString("0.00"));
    }





  

}