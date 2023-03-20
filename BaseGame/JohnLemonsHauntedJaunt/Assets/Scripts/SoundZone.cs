using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZone : MonoBehaviour
{
    public GameObject player;
    public SoundEffectSpawner.AudioName soundName;

    private void OnTriggerEnter(Collider other)
    {
        //Code Here: If the other collider matches the player, play the sound
    }
}
