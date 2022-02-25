using UnityEngine;

public class IndiviAudioPlayer : MonoBehaviour
{

    public void PlayString(string _name)
    {
        AudioManager.instance.Play(_name);
    }
}
