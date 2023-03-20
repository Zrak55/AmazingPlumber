using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectSpawner : MonoBehaviour
{
    [SerializeField] GameObject audioSourcePrefab;
    [SerializeField] AudioClip[] Footsteps;
    [SerializeField] AudioClip CaughtByGhost;

    static SoundEffectSpawner soundEffects;

    private void Start()
    {
        soundEffects = this;
    }

    public static void MakeSound(AudioName soundName, Vector3 location)
    {
        soundEffects.MakeSoundEffect(soundName, location);
    }

    public void MakeSoundEffect(AudioClip clip, Vector3 location, float volume, float pitch)
    {
        var go = Instantiate(audioSourcePrefab, location, Quaternion.identity);

        //Code Here: Get the audio Source from this gameObject.
        //           Set the clip, volume, and pitch, then play the clip


        Destroy(go, clip.length * 1.1f);
    }

    public void MakeSoundEffect(AudioName soundName, Vector3 location)
    {
        float volume = 1;
        float pitch = 1;

        AudioClip clip = null;

        //Code Here: Add code to determine what sound clip volume, and pitch to use basec on given soundName

        MakeSoundEffect(clip, location, volume, pitch);
    }

    public enum AudioName
    {
        Footstep,
        CaughtByGhost
    }
}
