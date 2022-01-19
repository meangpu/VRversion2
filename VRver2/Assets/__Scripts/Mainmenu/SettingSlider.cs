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

    [SerializeField] TMP_Text tableText;
    [SerializeField] Slider tableSlider;

    [Header("Volumn")]
    [SerializeField] TMP_Text masterVolText;

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




    }





  

}
