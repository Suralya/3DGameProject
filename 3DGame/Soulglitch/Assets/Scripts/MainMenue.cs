using UnityEngine;
using System.Collections;

public class MainMenue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLvl(){
		Application.LoadLevel (1);
	}

	public void quit(){
		Application.Quit();
	}
}
