using UnityEngine;
using System.Collections;
using System.Linq;

public class AIPlayer : Player {

	public bool civilian=true;
	public bool prop=false;

	// Use this for initialization
	void Start () {
		gridPosition.x = this.transform.position.x;
		gridPosition.y = this.transform.position.z;
		base.Ini ();
		transform.GetComponent<Renderer>().material.color = Color.yellow;

	}
	
	// Update is called once per frame
	void Update () {

		if (HP <= 0) {
			if(prop)
			{GameManager.instance.map.Find(t=>t.gridPosition==this.gridPosition).impassible=false;}
			gridPosition=default(Vector2);
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// enables Movement of the current Player (atm skips the AI turn)
	/// </summary>
	public override void TurnUpdate ()
	{
	/*	if (Vector3.Distance(moveDestination, transform.position) > 0.1f) {
			transform.position += (moveDestination - transform.position).normalized * moveSpeed * Time.deltaTime;
			
			if (Vector3.Distance(moveDestination, transform.position) <= 0.1f) {
				//transform.position = moveDestination;
				//moveDestination = new Vector3(0 + Mathf.Floor(GameManager.instance.mapSizeX-5),1.5f, -0 + Mathf.Floor(GameManager.instance.mapSizeY-5));
				//GameManager.instance.nextTurn();
			}
		} else {
			//moveDestination = new Vector3(0 + Mathf.Floor(GameManager.instance.mapSizeX/2),1.5f, -0 + Mathf.Floor(GameManager.instance.mapSizeY/2));
		//	GameManager.instance.nextTurn();
		}*/

		if (positionQueue.Count > 0) {
			transform.position += (positionQueue [0] - transform.position).normalized * moveSpeed * Time.deltaTime;
			
			if (Vector3.Distance (positionQueue [0], transform.position) <= 0.1f) {
				transform.position = positionQueue [0];
				positionQueue.RemoveAt (0);
				if (positionQueue.Count == 0) {
					//	actionPoints--;
				}
			}
		}
		
		base.TurnUpdate ();
	}

	public override void AIMove(){
		if (civilian) {
			GameManager.instance.SceneMovePatern.CivilianMove(this);
		} else {
			GameManager.instance.SceneMovePatern.EnemyMove(this);
		}
	}
}
