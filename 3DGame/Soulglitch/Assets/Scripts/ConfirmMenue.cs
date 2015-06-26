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

	/// <summary>
	/// Shows the confirm menue.
	/// </summary>
	public void ShowConfirmMenue(){

		Confirmcanvas.enabled = true;
	}

	/// <summary>
	/// Hides the confirm menue.
	/// </summary>
	public void HideConfirmMenue(){
		
		Confirmcanvas.enabled = false;
	}

	/// <summary>
	/// Quits the game.
	/// </summary>
	public void QuitGame(){

		Application.Quit();
	}
}
