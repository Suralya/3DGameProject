﻿using UnityEngine;
using System.Collections;

public class UserPlayer : Player {


	// Use this for initialization
	void Start () {
		gridPosition.x = this.transform.position.x;
		gridPosition.y = this.transform.position.z;
		base.Ini ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex] == this) {
			transform.GetComponent<Renderer>().material.color = Color.green;
		} else {
			transform.GetComponent<Renderer>().material.color = Color.white;
		}
		
		if (HP <= 0) {
			Vector3 temp;
			temp = this.transform.position;
			temp.y=1;
			transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
			transform.position=temp;
			transform.GetComponent<Renderer>().material.color = Color.red;

		    if (selected && GameManager.instance.UserPlayers.Exists(t => t.HP > 0))
		    {
		        Hotkey.hotk.NextPlayerasCurrent(GameManager.instance.currentPlayerIndex);
				Camermovement.instance.ChangeCamPosition();
		    }
			else{Debug.Log("GameOver");}
		}

	}

	/// <summary>
	/// Enables Movement of UserPlayers.
	/// </summary>
	public override void TurnUpdate ()
	{

		if (positionQueue.Count > 0) {
			transform.position += (positionQueue[0] - transform.position).normalized * moveSpeed * Time.deltaTime;
			
			if (Vector3.Distance(positionQueue[0], transform.position) <= 0.1f) {
				transform.position = positionQueue[0];
				positionQueue.RemoveAt(0);
				if (positionQueue.Count == 0) {
				//	actionPoints--;
				}
			}
			
		}
		
		base.TurnUpdate ();
}

}