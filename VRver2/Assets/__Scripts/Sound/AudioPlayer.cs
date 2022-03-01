using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] string playName = "mainBG";
    [SerializeField] bool StopOtherMusic;
    void Start()
    {
        if(StopOtherMusic)
        {
            AudioManager.instance.StopAllSound();   
        }

        playMainTheme();
    }


    public void playMainTheme()
    {
        if(AudioManager.instance.mainThemeIsplaying)
        {
            return;
        }
        else
        {
            AudioManager.instance.Play(playName);
            AudioManager.instance.mainThemeIsplaying = true;
        }
    }




}
