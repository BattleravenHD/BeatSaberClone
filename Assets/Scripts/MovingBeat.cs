using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBeat : MonoBehaviour
{
    public float speed = 10;
    public bool isRed;
    public Direction direction;
    public bool isDodge;

    Transform arrow;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = -transform.forward * speed;
        if (!isDodge)
        {
            arrow = transform.GetChild(1);
            switch (direction)
            {
                case Direction.None:
                    arrow.localScale = new Vector3(16, 16, 25);
                    arrow.localRotation = Quaternion.Euler(0, 180, 0);
                    break;
                case Direction.Up:
                    arrow.localScale = new Vector3(25, 16, 16);
                    arrow.localRotation = Quaternion.Euler(90, 0, -90);
                    break;
                case Direction.Down:
                    arrow.localScale = new Vector3(25, 16, 16);
                    arrow.localRotation = Quaternion.Euler(-90, 0, 90);
                    break;
                case Direction.Left:
                    arrow.localScale = new Vector3(25, 16, 16);
                    arrow.localRotation = Quaternion.Euler(0, 90, 0);
                    break;
                case Direction.Right:
                    arrow.localScale = new Vector3(25, 16, 16);
                    arrow.localRotation = Quaternion.Euler(0, -90, 0);
                    break;
                default:
                    break;
            }
        }
    }

}
