using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Win_Lose_Screen : MonoBehaviour
{
    public static Win_Lose_Screen instance;
    public Canvas ScreenCanvas;

	public Image WinLoseIMG;
	public Sprite Win, Lose;


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
		GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking=false;
		GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming=false;
		GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving=false;
		GameManager.instance.removeTileHighlights ();
		Time.timeScale=0;
		Hotkey.hotk.enabled = false;

        if (!ScreenCanvas.enabled)
        {
			WinLoseIMG.sprite=Win;
            Time.timeScale = 0;
            ScreenCanvas.enabled = true;
            Debug.Log("Game is Won");
        }
    }

    public void MissionLost()
    {
		GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking=false;
		GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming=false;
		GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving=false;
		GameManager.instance.removeTileHighlights ();
		Time.timeScale=0;
		Hotkey.hotk.enabled = false;

        if (!ScreenCanvas.enabled)
        {
			WinLoseIMG.sprite=Lose;
            Time.timeScale = 0;
            ScreenCanvas.enabled = true;
            Debug.Log("Game is Lost");
        }
    }

    public void BacktoMenue()
    {
		Time.timeScale=1;
		Hotkey.hotk.enabled = true;

        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    public void Retry()
    {
		Time.timeScale=1;
		Hotkey.hotk.enabled = true;

        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
}
