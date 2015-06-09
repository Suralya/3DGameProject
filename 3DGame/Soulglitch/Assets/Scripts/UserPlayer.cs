﻿using UnityEngine;
using System.Collections;

public class UserPlayer : Player {

	// Use this for initialization
	void Start () {
		gridPosition.x = this.transform.position.x;
		gridPosition.y = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex] == this) {
			transform.GetComponent<Renderer>().material.color = Color.green;
		} else {
			transform.GetComponent<Renderer>().material.color = Color.white;
		}
		
		if (HP <= 0) {
			transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
			transform.GetComponent<Renderer>().material.color = Color.red;
		}
	}

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