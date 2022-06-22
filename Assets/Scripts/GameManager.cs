using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BallCollisions ballCollisions;
    private BallMovement ballMovement;
    private UIMangager uIMangager;
    public float WaitTimeAfterGoal;

    public Transform RestartTransformPlayerLeft;
    public Transform RestartTransformPlayerRigth;

    private int LeftPlayerScore = 0;
    private int RightPlayerScore = 0;

    public KeyCode ResetKey;

    private void Update()
    {
        if (Input.GetKeyDown(ResetKey))
        {
            ResetGame();
        }
    }

    private void Start()
    {
        InitialSetUp();
        SubscribeToCollisions();
    }

    public void InitialSetUp()
    {
        ballCollisions = FindObjectOfType<BallCollisions>();
        ballMovement = FindObjectOfType<BallMovement>();
        uIMangager = FindObjectOfType<UIMangager>();
    }

    public void SubscribeToCollisions()
    {
        ballCollisions.OnPlayerCollision += PlayerCollision;
        ballCollisions.OnLeftGoalCollision += LeftGoalCollision;
        ballCollisions.OnRightGoalCollision += RightGoalCollision;
    }

    private void PlayerCollision()
    {
        ballMovement.IncreaseSpeed();
    }

    private void LeftGoalCollision()
    {
        Goal();
        RightPlayerScore++;
        uIMangager.SetRightPlayerScore(RightPlayerScore.ToString());
        ResetBall(RestartTransformPlayerLeft);
    }

    private void RightGoalCollision()
    {
        Goal();
        LeftPlayerScore++;
        uIMangager.SetLeftPlayerScore(LeftPlayerScore.ToString());
        ResetBall(RestartTransformPlayerRigth);
    }

    public void Goal()
    {
        StartCoroutine(WaitAfterGoal());
        uIMangager.StartCountDown(WaitTimeAfterGoal);
    }

    public void ResetBall(Transform InitialTransform)
    {
        ballCollisions.transform.position = InitialTransform.position;
        ballCollisions.transform.rotation = InitialTransform.rotation;
    }

    public IEnumerator WaitAfterGoal()
    {
        ballMovement.StopBall();
        yield return new WaitForSeconds(WaitTimeAfterGoal);
        ballMovement.RestartSpeed();
    }

    public void ResetGame()
    {
        uIMangager.SetLeftPlayerScore("0");
        uIMangager.SetRightPlayerScore("0");
        LeftPlayerScore = 0;
        RightPlayerScore = 0;
        ResetBall(RestartTransformPlayerLeft);
        ballMovement.RestartSpeed();
    }
}