using UnityEngine;
using System.Collections;

public class Charactertab : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)){
			NextPlayerasCurrent(GameManager.instance.currentPlayerIndex);
		}
	}

	public void NextPlayerasCurrent(int current){
		GameManager.instance.UserPlayers[current].selected=false;
		if (current<3){
			GameManager.instance.UserPlayers[current+1].selected=true;
			GameManager.instance.currentPlayerIndex=current+1;
		}else{
			GameManager.instance.UserPlayers[0].selected=true;
			GameManager.instance.currentPlayerIndex=0;
		}
		Debug.Log (" Player"+ (GameManager.instance.currentPlayerIndex+1) +" is selected");

	}


}
