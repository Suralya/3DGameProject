﻿using UnityEngine;
using System.Collections;

public class AIPlayer : Player {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void TurnUpdate ()
	{
		if (Vector3.Distance(moveDestination, transform.position) > 0.1f) {
			transform.position += (moveDestination - transform.position).normalized * moveSpeed * Time.deltaTime;
			
			if (Vector3.Distance(moveDestination, transform.position) <= 0.1f) {
				//transform.position = moveDestination;
				//moveDestination = new Vector3(0 + Mathf.Floor(GameManager.instance.mapSizeX-5),1.5f, -0 + Mathf.Floor(GameManager.instance.mapSizeY-5));
				GameManager.instance.nextTurn();
			}
		} else {
			//moveDestination = new Vector3(0 + Mathf.Floor(GameManager.instance.mapSizeX/2),1.5f, -0 + Mathf.Floor(GameManager.instance.mapSizeY/2));
			GameManager.instance.nextTurn();
		}
		
		base.TurnUpdate ();
	}
}