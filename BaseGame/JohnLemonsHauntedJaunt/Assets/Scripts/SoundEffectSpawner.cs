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
        var audioSource = go.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();

        Destroy(go, clip.length * 1.1f);
    }

    public void MakeSoundEffect(AudioName soundName, Vector3 location)
    {
        float volume = 1;
        float pitch = 1;

        AudioClip clip = null;

        switch(soundName)
        {
            case AudioName.Footstep:
                int index = Random.Range(0, Footsteps.Length);
                clip = Footsteps[index];
                pitch = Random.Range(0.5f, 1.5f);
                break;
            case AudioName.CaughtByGhost:
                volume = 1.5f;
                clip = CaughtByGhost;
                break;
            default:
                break;
        }

        MakeSoundEffect(clip, location, volume, pitch);
    }

    public enum AudioName
    {
        Footstep,
        CaughtByGhost
    }
}
