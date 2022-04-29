using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public Aladin aladin;
    private bool isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isActive && !aladin.isGameOverActive)
        {
            SetPause();
            isActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && isActive)
        {
            SetPlay();
            isActive = false;
        }
    }

    void SetPause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    void SetPlay()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
