using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform StartPosition, FinalPosition, ObstacleTransform;
    public float ObstacleWaitInPlaceTime, LerpTime;

    private void Start()
    {
        StartCoroutine(ObstacleMovement());
    }

    public IEnumerator ObstacleMovement()
    {
        while (true)
        {
            float elapsedTime = 0;
            while (elapsedTime < LerpTime)
            {
                yield return null;
                elapsedTime += Time.deltaTime;
                LerpObstaclePosition(StartPosition.position, FinalPosition.position, elapsedTime / LerpTime);
            }
            SwapPositions();
            yield return new WaitForSeconds(ObstacleWaitInPlaceTime);
        }
    }

    private void LerpObstaclePosition(Vector3 initialPos, Vector3 finalPos, float lerpTime)
    {
        ObstacleTransform.position = Vector3.Lerp(initialPos, finalPos, lerpTime);
    }

    private void SwapPositions()
    {
        Transform temp = StartPosition;
        StartPosition = FinalPosition;
        FinalPosition = temp;
    }
}