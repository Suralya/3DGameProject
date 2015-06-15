using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Characterbuttons : MonoBehaviour {

	public Text CharOne,CharTwo,CharThree,CharFour;
	public Button CharacterButtonOne,CharacterButtonTwo,CharacterButtonThree,CharacterButtonFour;


	// Use this for initialization
	void Start () {
		SetCharacterNames ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//DisableDeadChar ();
	}

	void SetCharacterNames(){
		CharOne.text = GameManager.instance.UserPlayers[0].playerName;
		CharTwo.text = GameManager.instance.UserPlayers[1].playerName;
		CharThree.text = GameManager.instance.UserPlayers[2].playerName;
		CharFour.text = GameManager.instance.UserPlayers[3].playerName;
	}

	void DisableDeadChar(){
		if (GameManager.instance.UserPlayers [0]==null) {CharacterButtonOne.interactable = false;}
		if (GameManager.instance.UserPlayers [1]==null) {CharacterButtonTwo.interactable = false;}
		if (GameManager.instance.UserPlayers [2]==null) {CharacterButtonThree.interactable = false;}
		if (GameManager.instance.UserPlayers [3]==null) {CharacterButtonFour.interactable = false;}
	}
	void HighlightSelected(){

	}

}
