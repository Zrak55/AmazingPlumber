using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public Transform player;
    
    public AudioSource normalMusicSource;
    public AudioSource dangerMusicSource;

    public AudioClip[] normalMusicClips;
    public AudioClip[] dangerMusicClips;


    // Update is called once per frame
    void Update()
    {
        bool foundDanger = false;
        foreach(var g in FindObjectsOfType<Observer>())
        {
            if (Vector3.Distance(player.position, g.transform.position) < 5)
            {
                foundDanger = true;
            }
        }

        //Code Here: Change source volume to match "Danger" setting

        //Code Here: Update tracks if a source stops playing

    }


}
