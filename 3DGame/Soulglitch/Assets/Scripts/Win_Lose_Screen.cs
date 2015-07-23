using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Win_Lose_Screen : MonoBehaviour
{
    public static Win_Lose_Screen instance;
    public Canvas ScreenCanvas;


    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    private void Start()
    {
        ScreenCanvas.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void MissionWon()
    {
        if (!ScreenCanvas.enabled)
        {
            Time.timeScale = 0;
            ScreenCanvas.enabled = true;
            Debug.Log("Game is Won");
        }
    }

    public void MissionLost()
    {
        if (!ScreenCanvas.enabled)
        {
            Time.timeScale = 0;
            ScreenCanvas.enabled = true;
            Debug.Log("Game is Lost");
        }
    }

    public void BacktoMenue()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
}
