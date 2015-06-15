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
		Application.LoadLevel (2);
	}

	public void quit(){
		Application.Quit();
	}

	public void Credits(){
		Application.LoadLevel (1);
	}
}
