using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (Time.timeScale == 1f)
                Time.timeScale = 0.05f;
            else
                Time.timeScale = 1f;
        }
    }
}
