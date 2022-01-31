using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] string playName = "mainBG";
    void Start()
    {
        AudioManager.instance.Play(playName);
    }


}
