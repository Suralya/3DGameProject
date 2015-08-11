using UnityEngine;
using System.Collections;

public class CursorChange : MonoBehaviour {

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;


	/*
	 void OnMouseEnter() {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}

	void OnMouseExit() {
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}

*/

	// Use this for initialization
	void Start () {

		Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
