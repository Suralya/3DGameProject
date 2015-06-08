using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {

	public Vector2 gridPosition = Vector2.zero;

	public int APCost = 1;
	public bool impassible = false;
	
	public List<Tile> neighbors = new List<Tile>();

	public GameManager GM ;

	// Use this for initialization
	void Start () {
		if (impassible) {
	//		transform.GetComponent<Renderer> ().material.color = Color.magenta;
		}
		gridPosition.x = this.transform.position.x;
		gridPosition.y = this.transform.position.z;

	}
	
	public void getNeighbors(){
		neighbors=(GM.map.FindAll(
			delegate(Tile obj) {
			return   ((gridPosition.x+1==obj.gridPosition.x&&gridPosition.y==obj.gridPosition.y)
			       ||(gridPosition.x==obj.gridPosition.x&&gridPosition.y+1==obj.gridPosition.y)
			       ||(gridPosition.x==obj.gridPosition.x&&gridPosition.y-1==obj.gridPosition.y)
			       ||(gridPosition.x-1==obj.gridPosition.x&&gridPosition.y==obj.gridPosition.y)
			          );
		}
		));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void OnMouseEnter(){
		transform.GetComponent<Renderer> ().material.color = Color.blue;
		Debug.Log ("my position is (" + gridPosition.x +","+gridPosition.y+")");
	}

	void OnMouseExit(){
		if (!impassible) {
			transform.GetComponent<Renderer> ().material.color = Color.white;
		} else {
			transform.GetComponent<Renderer> ().material.color = Color.magenta;
		}
	}
*/
	void OnMouseDown() {
		if (GM.UserPlayers [GM.currentPlayerIndex].moving) {
			GM.moveCurrentPlayer (this);
			Debug.Log ("Wurde übergebn"+this.transform.position.x+","+this.transform.position.z);
		} else if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking) {
		//	GameManager.instance.attackWithCurrentPlayer(this);
			Debug.Log ("Angriff auf"+this.transform.position.x+","+this.transform.position.z);
	}
}

}