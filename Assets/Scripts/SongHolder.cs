using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSong", menuName = "ScriptableObjects/Song", order = 1)]
public class SongHolder : ScriptableObject
{
    public string songName = "NewSong";
    public AudioClip audio;
    public int highScore = 0;
    public float songLength = 0;
    public float bias = 3;
    public float timeStep = 0.35f;
    public float beatSpeed = 3;
    public float dodgeThreshold = 1;
    public int maxOtherSideBeats = 2;
}
