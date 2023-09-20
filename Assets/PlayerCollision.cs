using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {
        MovingBeat beat;
        if (other.TryGetComponent<MovingBeat>(out beat))
        {
            if (beat.isDodge)
            {
                playerStats.FailedSlice();
            }
        }
    }
}
