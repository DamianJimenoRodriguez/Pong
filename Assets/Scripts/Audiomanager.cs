using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public AudioClip WallSound, PlayerSound, GoalSound;
    private AudioSource audioSource;
    private BallCollisions ballCollisions;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        audioSource = GetComponent<AudioSource>();
        ballCollisions = FindObjectOfType<BallCollisions>();
        ballCollisions.OnPlayerCollision += PlayerAudio;
        ballCollisions.OnLeftGoalCollision += GoalAudio;
        ballCollisions.OnRightGoalCollision += GoalAudio;
        ballCollisions.OnWallCollision += WallAudio;
    }

    public void PlayerAudio()
    {
        audioSource.PlayOneShot(PlayerSound);
    }

    public void WallAudio()
    {
        audioSource.PlayOneShot(WallSound);
    }

    public void GoalAudio()
    {
        audioSource.PlayOneShot(GoalSound);
    }
}