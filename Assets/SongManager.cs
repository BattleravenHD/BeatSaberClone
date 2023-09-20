using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public AudioSource main;
    public AudioSource spectrum;
    public SongHolder song;
    public AutomatedBeatSpawner spawner;
    public GameObject UI;

    public float delay;
    public PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void stopSong()
    {
        main.Stop();
        spectrum.Stop();
        StopAllCoroutines();
        UI.SetActive(true);
    }

    public void startSong(SongHolder son)
    {
        song = son;
        spectrum.clip = song.audio;
        main.clip = song.audio;
        spawner.bias = song.beatSpeed;
        spawner.timeStep = song.timeStep;
        spawner.dodgeThreshold = song.dodgeThreshold;
        spawner.beatSpeed = song.beatSpeed;
        spawner.maxOtherSideBeats = song.maxOtherSideBeats;
        delay = 1.13f * song.beatSpeed / 6.5f;
        spectrum.Play();
        StartCoroutine(delayedStart());
        StartCoroutine(stopAfterFinish());
    }

    IEnumerator delayedStart()
    {
        yield return new WaitForSeconds(delay);
        main.Play();
    }
    IEnumerator stopAfterFinish()
    {
        yield return new WaitForSeconds(song.songLength);
        stopSong();
        stats.addHighScore();
    }
}
