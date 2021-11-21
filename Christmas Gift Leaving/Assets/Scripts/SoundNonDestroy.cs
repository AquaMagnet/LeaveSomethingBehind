using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundNonDestroy : MonoBehaviour
{
    SoundsSetting musicVol;
    //aAudioMixer audioMixer;
    private void Start()
    {
        musicVol = FindObjectOfType<SoundsSetting>();
        
    }

    public void ChangeVolume(float volume)
    {
        musicVol.SetVolume(volume);
    }
}
