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
        if(foundDanger)
        {
            dangerMusicSource.volume = Mathf.MoveTowards(dangerMusicSource.volume, 1f, Time.deltaTime);
            normalMusicSource.volume = Mathf.MoveTowards(normalMusicSource.volume, 0f, Time.deltaTime);

        }
        else
        {
            dangerMusicSource.volume = Mathf.MoveTowards(dangerMusicSource.volume, 0f, Time.deltaTime);
            normalMusicSource.volume = Mathf.MoveTowards(normalMusicSource.volume, 1f, Time.deltaTime);
        }


        //Code Here: Update tracks if a source stops playing
        if(normalMusicSource.isPlaying == false)
        {
            normalMusicSource.clip = normalMusicClips[Random.Range(0, normalMusicClips.Length)];
            normalMusicSource.Play();
        }
        if(dangerMusicSource.isPlaying == false)
        {
            dangerMusicSource.clip = dangerMusicClips[Random.Range(0, dangerMusicClips.Length)];
            dangerMusicSource.Play();
        }

    }


}
