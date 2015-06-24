using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PauseMenue : MonoBehaviour {

	private bool GameisPaused =false;
	public Canvas Menuecanvas;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ShowPauseMenue ();

	if (Input.GetKeyDown(KeyCode.P) && !GameisPaused) {
			GameisPaused = true;
			Debug.Log("GameisPaused");
		} else if (Input.GetKeyDown(KeyCode.P) && GameisPaused){
			GameisPaused = false;
			Debug.Log("GameResumed");
		}
	}

	public void ShowPauseMenue(){
		if (GameisPaused) {
			Menuecanvas.enabled = true;
		} else {
			Menuecanvas.enabled = false;
		}
	}

	public void ResumeGame(){
		GameisPaused = false;
		Debug.Log("GameResumed");
	}

	public void BacktoMenue(){
		Application.LoadLevel (0);
	}
	
	public void quit(){
		Application.Quit();
	}
}
