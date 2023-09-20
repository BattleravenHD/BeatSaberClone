using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedBeatSpawner : AudioSyncer
{
    public AudioSource main;
    public Transform[] spawnPoints;

    public GameObject[] cubes;
    public float dodgeThreshold = 1;
    public float beatSpeed = 2;
    public int maxOtherSideBeats = 2;

    Direction leftSideDirection;
    Direction rightSideDirection;

    int nextLeft = 0;
    int nextRight = 3;
    float timeSinceBeat = 0;

    bool redside = true;

    int beat = 0;

    private void Start()
    {
        leftSideDirection = Direction.None;
        rightSideDirection = Direction.None;
    }

    public override void OnBeat()
    {
        if (redside == false)
        {
            beat++;
            if (beat >= maxOtherSideBeats)
            {
                redside = true;
                beat = 0;
            }
        }
        base.OnBeat();
        timeSinceBeat = 0;
        if (Random.Range(0, 2) == 0)
        {
            MovingBeat beat = Instantiate(cubes[System.Convert.ToInt32(!redside)], spawnPoints[nextLeft].position, Quaternion.identity).GetComponent<MovingBeat>();
            beat.speed = beatSpeed;
            beat.direction = calculateDirection(true);
            if (beat.direction == Direction.Right && rightSideDirection == Direction.Left)
            {
                redside = !redside;
            }
            if (beat.direction == Direction.Up)
            {
                nextLeft = Mathf.Clamp(nextLeft + 1, 0, 2);
            }
            if (beat.direction == Direction.Down)
            {
                nextLeft = Mathf.Clamp(nextLeft - 1, 0, 2);
            }
        }
        else
        {
            MovingBeat beat = Instantiate(cubes[System.Convert.ToInt32(redside)], spawnPoints[nextRight].position, Quaternion.identity).GetComponent<MovingBeat>();
            beat.speed = beatSpeed;
            beat.direction = calculateDirection(false);
            if (beat.direction == Direction.Right && leftSideDirection == Direction.Left)
            {
                redside = !redside;
            }
            if (beat.direction == Direction.Up)
            {
                nextRight = Mathf.Clamp(nextRight + 1, 3, 5);
            }
            if (beat.direction == Direction.Down)
            {
                nextRight = Mathf.Clamp(nextRight - 1, 3, 5);
            }
        }
    }

    Direction calculateDirection(bool isLeft)
    {
        if (isLeft)
        {
            int rand = Random.Range(0, 5);
            switch (leftSideDirection)
            {
                case Direction.None:
                    if (nextLeft == 0)
                    {
                        leftSideDirection = Direction.Up;
                    }
                    else if (nextLeft == 2)
                    {
                        leftSideDirection = Direction.Down;
                    }
                    else
                    {
                        leftSideDirection = (Direction)Random.Range(1, 5);
                    }
                    break;
                case Direction.Up:
                    if (nextLeft == 2)
                    {
                        leftSideDirection = Direction.Down;
                    }
                    else
                    {
                        while (rand == 1)
                        {
                            rand = Random.Range(0, 5);
                        }
                        leftSideDirection = (Direction)rand;
                    }
                    break;
                case Direction.Down:
                    if (nextLeft == 0)
                    {
                        leftSideDirection = Direction.Up;
                    }
                    else
                    {
                        while (rand == 2)
                        {
                            rand = Random.Range(0, 5);
                        }
                        leftSideDirection = (Direction)rand;
                    }
                    break;
                case Direction.Left:
                    while (rand == 3)
                    {
                        rand = Random.Range(0, 5);
                    }
                    leftSideDirection = (Direction)rand;
                    break;
                case Direction.Right:
                    leftSideDirection = (Direction)Random.Range(0, 4);
                    break;
                default:
                    break;
            }
            return leftSideDirection;
        }else
        {
            int rand = Random.Range(0, 5);
            switch (rightSideDirection)
            {
                case Direction.None:
                    if (nextRight == 3)
                    {
                        rightSideDirection = Direction.Up;
                    }
                    else if (nextRight == 5)
                    {
                        rightSideDirection = Direction.Down;
                    }
                    else
                    {
                        rightSideDirection = (Direction)Random.Range(1, 5);
                    }
                    break;
                case Direction.Up:
                    if (nextRight == 5)
                    {
                        rightSideDirection = Direction.Down;
                    }
                    else
                    {
                        while (rand == 1)
                        {
                            rand = Random.Range(0, 5);
                        }
                        rightSideDirection = (Direction)rand;
                    }
                    break;
                case Direction.Down:
                    if (nextRight == 3)
                    {
                        rightSideDirection = Direction.Up;
                    }
                    else
                    {
                        while (rand == 2)
                        {
                            rand = Random.Range(0, 5);
                        }
                        rightSideDirection = (Direction)rand;
                    }
                    break;
                case Direction.Left:
                    while (rand == 3)
                    {
                        rand = Random.Range(0, 5);
                    }
                    rightSideDirection = (Direction)rand;
                    break;
                case Direction.Right:
                    rightSideDirection = (Direction)Random.Range(0, 4);
                    break;
                default:
                    break;
            }
            return rightSideDirection;
        }
    }


    public override void OnUpdate()
    {
        timeSinceBeat += Time.deltaTime;
        base.OnUpdate();
        if (main.isPlaying && timeSinceBeat > dodgeThreshold)
        {
            MovingBeat beat = Instantiate(cubes[2], spawnPoints[Random.Range(0, 6)].position, Quaternion.identity).GetComponent<MovingBeat>();
            timeSinceBeat = 0;
            beat.speed = beatSpeed;
        }
    }
}

public enum Direction
{
    None,
    Up,
    Down,
    Left,
    Right
}