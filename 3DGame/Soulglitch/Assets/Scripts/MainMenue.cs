using UnityEngine;
using System.Collections;

public class MainMenue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Loads the lvl.
	/// </summary>
	public void LoadLvl(){
		Application.LoadLevel (2);
	}

	/// <summary>
	/// Loads Credits.
	/// </summary>
	public void Credits(){
		Application.LoadLevel (1);
	}
}
