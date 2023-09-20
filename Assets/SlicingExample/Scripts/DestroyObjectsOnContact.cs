using UnityEngine;

public class DestroyObjectsOnContact : MonoBehaviour
{
    public PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovingBeat>() && !other.GetComponent<MovingBeat>().isDodge)
        {
            playerStats.FailedSlice();
        }
        if (other.attachedRigidbody != null)
        {
            Destroy(other.attachedRigidbody.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
