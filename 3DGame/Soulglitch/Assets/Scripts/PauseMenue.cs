using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PauseMenue : MonoBehaviour {

	private bool GameisPaused =false;
	public List<Button> InterfaceButtons= new List<Button>();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.P) && !GameisPaused) {
			Time.timeScale = 0.0f;
			GameisPaused = true;
			Debug.Log("GameisPaused");
		} else if (Input.GetKeyDown(KeyCode.P) && GameisPaused){
			Time.timeScale = 1.0f;
			GameisPaused = false;
			Debug.Log("GameResumed");
		}
	}

	public void ShowPauseMenue(){

	}

	public void disableInterface(){

	}
}
