using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingSlider : MonoBehaviour
{
    [Header("Height")]
    [SerializeField] TMP_Text eyeText;
    [SerializeField] Slider eyeSlider;
    [SerializeField] Transform eyeTrans;
    [SerializeField] Transform headValue;
    // [SerializeField] TMP_Text nowHeadText;
    [SerializeField] bool SetALLText;
    [SerializeField] bool LoadFromSaved;

    [Header("VolumnMixer")]
    [SerializeField] AudioMixer mixer;
    [Header("Volumn")]
    [SerializeField] TMP_Text masterVolText;
    [SerializeField] Slider masterVolSlider;
    
    [SerializeField] TMP_Text sfxVolText;
    [SerializeField] Slider sfxVolSlider;

    [SerializeField] TMP_Text musicVolText;
    [SerializeField] Slider musicVolSlider;

    private void Start() 
    {
        if (SetALLText)
        {
            setAllText();
            eyeSlider.onValueChanged.AddListener((v) => 
            {
                eyeText.SetText(v.ToString("0.00"));
            });
        }

        // volumn
        masterVolSlider.onValueChanged.AddListener((v) => 
        {
            masterVolText.SetText((v*10).ToString("0"));
            mixer.SetFloat("Master", Mathf.Log10(v)*20);

            PlayerPrefs.SetFloat("SoundMaster", v);
        });

        sfxVolSlider.onValueChanged.AddListener((v) => 
        {
            sfxVolText.SetText((v*10).ToString("0"));
            mixer.SetFloat("SFX", Mathf.Log10(v)*20);

            PlayerPrefs.SetFloat("SoundSFX", v);
        });

        musicVolSlider.onValueChanged.AddListener((v) => 
        {
            musicVolText.SetText((v*10).ToString("0"));
            mixer.SetFloat("BG", Mathf.Log10(v)*20);

            PlayerPrefs.SetFloat("SoundBG", v);
        });
        
        
        if (LoadFromSaved)
        {
            LoadAllSavedValue();
        }

    }


    public void changeEyeByValue(float _v)
    {
        eyeSlider.value += _v;
    }

    public void SetEyeByNumber(float _v)
    {
        Vector3 newH = new Vector3(eyeTrans.localPosition.x, _v, eyeTrans.localPosition.z);
        eyeTrans.localPosition = newH;
        PlayerPrefs.SetFloat("EyeLevel", _v);
    }

    public void setEyeLevel()
    {
        SetEyeByNumber(eyeSlider.value);
    }

    public void resetEyeLevel()
    {
        SetEyeByNumber(0);
        eyeSlider.value = 0;
        eyeText.SetText(eyeSlider.value.ToString("0.00"));
    }

    public void LoadAllSavedValue()
    {
        // eye part
        float oldEyeValue = PlayerPrefs.GetFloat("EyeLevel");
        Vector3 newH = new Vector3(eyeTrans.localPosition.x, oldEyeValue, eyeTrans.localPosition.z);
        eyeTrans.localPosition = newH;
        Debug.Log(eyeTrans);
        Debug.Log($"Set Eye Trans! to {newH}");

        if (eyeText != null)
        {
            eyeSlider.value = oldEyeValue;
            eyeText.SetText(eyeSlider.value.ToString("0.00"));
        }

        // sound part
        float saved_Master = PlayerPrefs.GetFloat("SoundMaster");
        float saved_SFX = PlayerPrefs.GetFloat("SoundSFX");
        float saved_BG = PlayerPrefs.GetFloat("SoundBG");

        masterVolSlider.value = saved_Master;
        sfxVolSlider.value = saved_SFX;
        musicVolSlider.value = saved_BG;

        masterVolText.SetText((masterVolSlider.value*10).ToString("0"));
        sfxVolText.SetText((sfxVolSlider.value*10).ToString("0"));
        musicVolText.SetText((musicVolSlider.value*10).ToString("0"));

        mixer.SetFloat("Master", Mathf.Log10(masterVolSlider.value)*20);
        mixer.SetFloat("SFX", Mathf.Log10(sfxVolSlider.value)*20);
        mixer.SetFloat("BG", Mathf.Log10(musicVolSlider.value)*20);

    }

    public void setAllText()
    {
        eyeText.SetText(eyeSlider.value.ToString("0.00"));

        masterVolText.SetText((masterVolSlider.value*10).ToString("0"));
        sfxVolText.SetText((sfxVolSlider.value*10).ToString("0"));
        musicVolText.SetText((musicVolSlider.value*10).ToString("0"));

        mixer.SetFloat("Master", Mathf.Log10(masterVolSlider.value)*20);
        mixer.SetFloat("SFX", Mathf.Log10(sfxVolSlider.value)*20);
        mixer.SetFloat("BG", Mathf.Log10(musicVolSlider.value)*20);

    }

    // public void getEyeValueNow()
    // {
    //     float nowhead = headValue.transform.localPosition.y;
    //     nowHeadText.SetText(nowhead.ToString("0.00"));
    // }





  

}
