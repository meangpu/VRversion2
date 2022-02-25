using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sizeRotController : MonoBehaviour
{
    [SerializeField] Transform pref;

    [SerializeField] TMP_Text rotText;
    [SerializeField] Slider rotSlider;

    [SerializeField] TMP_Text sizeText;
    [SerializeField] Slider sizeSlider;


    void Start()
    {
        rotSlider.onValueChanged.AddListener((v) => 
        {
            pref.rotation = Quaternion.Euler(0, v, 0);
            updateAllText();
        });

        sizeSlider.onValueChanged.AddListener((v) => 
        {
            pref.localScale = new Vector3(v,v,v);
            updateAllText();
        });

        updateAllText();

    }

    public void updateAllText()
    {
        rotText.SetText(rotSlider.value.ToString("0"));
        sizeText.SetText(sizeSlider.value.ToString("0.00"));
    }


}
