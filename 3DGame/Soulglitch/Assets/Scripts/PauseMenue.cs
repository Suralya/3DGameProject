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
		} else {
			Time.timeScale = 1.0f;
			GameisPaused = false;
		}
	}

	public void ShowPauseMenue(){

	}

	public void disableInterface(){

	}
}
