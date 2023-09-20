using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiSongManager : MonoBehaviour
{
    public SongHolder[] songs;
    public GameObject uiSongHolder;
    public GameObject scrollViewArea;
    public SongManager songManager;
    public PlayerStats stats;

    int currentDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (SongHolder song in songs)
        {
            GameObject text = Instantiate(uiSongHolder, scrollViewArea.transform);
            Button but = text.GetComponent<Button>();
            text.GetComponent<RectTransform>().localPosition = new Vector3(0, currentDistance, 0);
            but.onClick.AddListener(stats.newSong);
            but.onClick.AddListener(delegate { songManager.startSong(song); });
            but.onClick.AddListener(delegate { transform.parent.gameObject.SetActive(false); });
            
            text.GetComponentInChildren<TMP_Text>().text = song.songName;
            currentDistance -= 35;
        }
    }
}
