using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectSpawner : MonoBehaviour
{
    [SerializeField] GameObject audioSourcePrefab;
    [SerializeField] AudioClip[] Footsteps;
    [SerializeField] AudioClip CaughtByGhost;
    [SerializeField] AudioClip WinGame;

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

        AudioSource source = go.GetComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;

        source.Play();

        Destroy(go, clip.length * 1.1f);
    }

    public void MakeSoundEffect(AudioName soundName, Vector3 location)
    {
        float volume = 1;
        float pitch = 1;

        AudioClip clip = null;

       switch(soundName)
        {
            case AudioName.CaughtByGhost:
                clip = CaughtByGhost;
                volume = 1f;
                pitch = 1f;
                break;
            case AudioName.WinGame:
                clip = WinGame;
                volume = 0.75f;
                pitch = Random.Range(0.9f, 1.1f);
                break;
            case AudioName.Footstep:
                clip = Footsteps[Random.Range(0, Footsteps.Length)];
                volume = 1f;
                pitch = 1f;
                break;
        }

        MakeSoundEffect(clip, location, volume, pitch);
    }

    public enum AudioName
    {
        Footstep,
        CaughtByGhost,
        WinGame
    }
}
