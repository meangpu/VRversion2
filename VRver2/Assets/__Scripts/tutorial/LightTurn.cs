using UnityEngine;

public class LightTurn : MonoBehaviour
{
    [SerializeField] GameObject _light;
    private bool isOn;

    public void buttonLight()
    {
        if(isOn)  // เปิด ให้ปิด
        {
            _light.SetActive(false);
        }
        else
        {
            _light.SetActive(true);
        }
        isOn = !isOn;
    }

    
}
