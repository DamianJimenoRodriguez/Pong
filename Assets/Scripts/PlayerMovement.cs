using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 30;

    private PlayerInput playerInput;

    public Transform TopLimit;
    public Transform BottonLimit;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        SubscribeToInput();
    }

    private void SubscribeToInput()
    {
        playerInput.OnUpInput += UpMovement;
        playerInput.OnDownInput += DownMovement;
    }

    private void Update()
    {
        ClampVerticalPosition();
    }

    private void UpMovement()
    {
        transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
    }

    private void DownMovement()
    {
        transform.position += new Vector3(0, -Speed * Time.deltaTime, 0);
    }

    private void ClampVerticalPosition()
    {
        Vector3 NewPos = transform.position;
        NewPos.y = Mathf.Clamp(NewPos.y, BottonLimit.position.y, TopLimit.position.y);
        transform.position = NewPos;
    }
}