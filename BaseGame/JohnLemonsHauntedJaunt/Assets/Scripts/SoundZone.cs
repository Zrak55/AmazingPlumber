using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZone : MonoBehaviour
{
    public GameObject player;
    public SoundEffectSpawner.AudioName soundName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            SoundEffectSpawner.MakeSound(soundName, player.transform.position);
        }
    }
}
