using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsSetting : MonoBehaviour
{
    public AudioMixer audioMixer;


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
