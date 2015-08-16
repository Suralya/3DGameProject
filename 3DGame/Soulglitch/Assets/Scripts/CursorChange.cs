using UnityEngine;
using System.Collections;

public class CursorChange : MonoBehaviour {

	public Texture2D cursorTexture;
	public Texture2D cursorTextureattack;
	public Texture2D cursorTexturemove;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;



	// Use this for initialization
	void Start () {

		Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].attacking || GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].aiming) {
			Cursor.SetCursor (cursorTextureattack, hotSpot, cursorMode);
		} else if (GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].moving) {
			Cursor.SetCursor (cursorTexturemove, hotSpot, cursorMode);
		}
		else{Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);}
	
	}
}
