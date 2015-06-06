using UnityEngine;
using System.Collections;

public class UserPlayer : Player {

	public GameObject Figur; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
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
		//highlight
		//
		//
		
		if (positionQueue.Count > 0) {
			transform.position += (positionQueue[0] - transform.position).normalized * moveSpeed * Time.deltaTime;
			
			if (Vector3.Distance(positionQueue[0], transform.position) <= 0.1f) {
				transform.position = positionQueue[0];
				positionQueue.RemoveAt(0);
				if (positionQueue.Count == 0) {
					AP--;
				}
			}
			
		}
		
		base.TurnUpdate ();
	}

	public void movePlayer(){
		if (!moving&&selected) {
			GameManager.instance.removeTileHighlights ();
			moving = true;
			attacking = false;
			GameManager.instance.highlightTilesAt (gridPosition, Color.blue, AP);
		} else {
			moving = false;
			attacking = false;
			GameManager.instance.removeTileHighlights ();
		}
	}

	public void attackPlayer()
	{
		if (!attacking&&selected) {
			GameManager.instance.removeTileHighlights();
			moving = false;
			attacking = true;
			GameManager.instance.highlightTilesAt(gridPosition, Color.red, attackRange);
		} else {
			moving = false;
			attacking = false;
			GameManager.instance.removeTileHighlights();
		}
	}
	
	
}
