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
                dangerMusicSource.volume = Mathf.Clamp(dangerMusicSource.volume + Time.deltaTime, 0, 1);
                normalMusicSource.volume = Mathf.Clamp(normalMusicSource.volume - Time.deltaTime, 0, 1);
            }
        }
        if(foundDanger == false)
        {

            dangerMusicSource.volume = Mathf.Clamp(dangerMusicSource.volume - Time.deltaTime, 0, 1); 
            normalMusicSource.volume = Mathf.Clamp(normalMusicSource.volume + Time.deltaTime, 0, 1); 
        }

        if(normalMusicSource.isPlaying == false)
        {
            int rand = Random.Range(0, normalMusicClips.Length);
            normalMusicSource.clip = normalMusicClips[rand];
            normalMusicSource.Play();
        }
        if(dangerMusicSource.isPlaying == false)
        {
            int rand = Random.Range(0, dangerMusicClips.Length);
            dangerMusicSource.clip = dangerMusicClips[rand];
            dangerMusicSource.Play();
        }
    }


}
