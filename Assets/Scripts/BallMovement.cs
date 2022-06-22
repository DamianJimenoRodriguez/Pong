using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Update is called once per frame
    private float speed;

    [Range(1, 9)]
    public float InitialSpeed;

    [Range(10, 15)]
    public float MaxSpeed;

    [Range(1, 5)]
    public float SpeedIncrements;

    private void Start()
    {
        RestartSpeed();
    }

    public void RestartSpeed()
    {
        speed = InitialSpeed;
    }

    public void StopBall()
    {
        speed = 0;
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    public void IncreaseSpeed()
    {
        speed += SpeedIncrements;
        speed = Mathf.Clamp(speed, 0, MaxSpeed);
    }
}