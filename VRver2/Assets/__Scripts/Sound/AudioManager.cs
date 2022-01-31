using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    // FindObjectOfType<AudioManager>().Play("soundName");

    public Sound[] sounds;
    public static AudioManager instance;

    private AudioSource[] allAudioSources;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volumn;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.mixerGroup;
            s.source.spatialBlend = s.blend;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        if(s==null)
        {
            return;
        }
        s.source.Play();
    }

    public void PlayOne(string name, float vol)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        if(s==null)
        {
            return;
        }
        s.source.PlayOneShot(s.clip, vol);
    }

    public void PlayAddPitch(string name, float addingValue, bool doPlay=true)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        if(s==null)
        {
            return;
        }
        s.pitch += addingValue;
        s.source.pitch = s.pitch;
        if(doPlay)
        {
            s.source.Play();
        }   
        
    }

    public void StopAllSound()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource aud in allAudioSources)
        {
            aud.Stop();
        }
    }
    


}
