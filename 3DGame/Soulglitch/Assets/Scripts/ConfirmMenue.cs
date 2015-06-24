using UnityEngine;
using System.Collections;

public class ConfirmMenue : MonoBehaviour {

	public Canvas Confirmcanvas;

	// Use this for initialization
	void Start () {
		HideConfirmMenue ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowConfirmMenue(){

		Confirmcanvas.enabled = true;
	}

	public void HideConfirmMenue(){
		
		Confirmcanvas.enabled = false;
	}

	public void QuitGame(){

		Application.Quit();
	}
}
