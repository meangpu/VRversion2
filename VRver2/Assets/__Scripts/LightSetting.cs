using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightSetting : MonoBehaviour
{
    [SerializeField] Light[] allSpotLight;
    [SerializeField] Slider lightSlider;
    [SerializeField] TMP_Text lightTextVal;

    void Start()
    {
        lightSlider.onValueChanged.AddListener((v) => 
        {
            lightTextVal.SetText(v.ToString("0.00"));
            setAllLight(v);
        });

    }

    void setAllLight(float inten)
    {
        foreach (Light _light in allSpotLight)
        {
            _light.intensity = inten;
        }
    }


}
