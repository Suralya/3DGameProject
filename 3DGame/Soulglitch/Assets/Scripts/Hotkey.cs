using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hotkey : MonoBehaviour {
	public static Hotkey hotk;

	void Awake() {
		hotk = this;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)){
			GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking=false;
			GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving=false;
			GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming=false;
			GameManager.instance.removeTileHighlights ();
			GameManager.instance.Tooltiptext.text=" ";

			NextPlayerasCurrent(GameManager.instance.currentPlayerIndex);
			Camermovement.instance.ChangeCamPosition();
		}
		if (Input.GetKeyDown (KeyCode.A)&&GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].actionPoints>=GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.APCost) {GameManager.instance.attackPlayer();}
		if (Input.GetKeyDown (KeyCode.M)&&GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].actionPoints>0) {GameManager.instance.movePlayer();}
		if (Input.GetKeyDown (KeyCode.S)&&GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].actionPoints>0) {GameManager.instance.aimPlayer();}
		if (Input.GetKeyDown (KeyCode.T)) {GameManager.instance.showhideTooltip();}

	}

	public void NextPlayerasCurrent(int current){

		GameManager.instance.UserPlayers[current].selected=false;
		if (current<3){
			GameManager.instance.formerPlayerIndex=GameManager.instance.currentPlayerIndex;
			GameManager.instance.UserPlayers[current+1].selected=true;
			GameManager.instance.currentPlayerIndex=current+1;
		}else{
			GameManager.instance.formerPlayerIndex=GameManager.instance.currentPlayerIndex;
			GameManager.instance.UserPlayers[0].selected=true;
			GameManager.instance.currentPlayerIndex=0;
		}
		Debug.Log (" Player"+ (GameManager.instance.currentPlayerIndex+1) +" is selected");


		
	}

}
