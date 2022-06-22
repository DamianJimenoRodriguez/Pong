using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public System.Action OnUpInput;

    public System.Action OnDownInput;

    public KeyCode UpKey;
    public KeyCode DownKey;

    private void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        if (Input.GetKey(UpKey))
        {
            if (OnUpInput != null)
            {
                OnUpInput();
            }
        }
        if (Input.GetKey(DownKey))
        {
            if (OnDownInput != null)
            {
                OnDownInput();
            }
        }
    }
}