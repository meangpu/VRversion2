using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class pauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseVolumn;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] float maxWaitTime;
    private float timeBetweenWait;
    public XRNode inputSource;
    private bool isMenuPress;
    private bool isPaused = false;



    void Start()
    {
        unpauseGame();
    }


    private void Update() 
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.menuButton, out isMenuPress);

        if (timeBetweenWait > 0)
        {
            timeBetweenWait -= Time.unscaledDeltaTime;
        }
        else
        {
            if (isMenuPress)
            {
                if(isPaused)  // หยุดอยู่ให้เลิกหยุด
                {
                    unpauseGame();
                }
                else  // ไม่หยุดให้หยุด
                {
                    pauseGame();
                }
                isPaused = !isPaused;
            }
            else
            {
                return;
            }
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseVolumn.SetActive(true);
        pauseCanvas.SetActive(true);
        timeBetweenWait = maxWaitTime;
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
        pauseVolumn.SetActive(false);
        pauseCanvas.SetActive(false);
        timeBetweenWait = maxWaitTime;
    }


}
