using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int Score = 0;
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int failImpact = 20;
    public float maxMulitiplier = 2.0f;
    public Slider healthBar;
    public SongManager songManager;
    public GameObject songChoicer;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    float scoreGainMultiplier = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
        scoreText.text = "Score:\n" + Score;
        if (songManager.song)
        {
            highScoreText.text = "High Score:\n" + songManager.song.highScore;
        }
        if (currentHealth <= 0)
        {
            songManager.stopSong();
            songChoicer.SetActive(true);
            currentHealth = maxHealth;
        }
    }
    
    public void addHighScore()
    {
        if (songManager.song && Score > songManager.song.highScore)
        {
            songManager.song.highScore = Score;
        }
    }

    public void newSong()
    {
        currentHealth = maxHealth;
        Score = 0;
    }

    public void GoodSlice()
    {
        currentHealth = Mathf.Clamp(currentHealth + Mathf.RoundToInt(failImpact/2 * scoreGainMultiplier), 0, maxHealth);
        Score += Mathf.RoundToInt(failImpact / 2 * scoreGainMultiplier);
    }

    public void FailedSlice()
    {
        scoreGainMultiplier = 0.5f;
        currentHealth -= failImpact;
    }
}
