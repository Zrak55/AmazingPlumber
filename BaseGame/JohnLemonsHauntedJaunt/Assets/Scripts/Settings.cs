using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audio;

    public void SetMainVolume(float value)
    {
        audio.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }
    public void SetSoundEffectVolume(float value)
    {
        audio.SetFloat("SoundEffectVolume", Mathf.Log10(value) * 20);
    }
    public void SetAmbienceVolume(float value)
    {
        audio.SetFloat("AmbienceVolume", Mathf.Log10(value) * 20);
    }
    public void SetMusicVolume(float value)
    {
        audio.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }



}
