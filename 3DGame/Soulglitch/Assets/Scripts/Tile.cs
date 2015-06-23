using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tile : MonoBehaviour {

	public Vector2 gridPosition = Vector2.zero;

	public int APCost = 1;
	public bool impassible = false;

	public bool occupied=false;
	
	public List<Tile> neighbors = new List<Tile>();

	public GameManager GM ;

	// Use this for initialization
	void Start () {
		if (impassible) {
			//transform.GetComponent<Renderer> ().material.color = Color.magenta;
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
		if (GM.UserPlayers.Any (delegate(Player obj) {return obj.gridPosition == gridPosition;})&&GameManager.instance.UserPlayers[GameManager.instance.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition)].HP>0 
		   || GM.AIPlayers.Any (delegate(Player obj) {return obj.gridPosition == gridPosition;})) 
		{
			occupied = true;
		} else {
			occupied = false;
		}

	
	}

	void OnMouseEnter(){
		if (transform.GetComponent<Renderer> ().material.color == Color.white && !impassible) {
			transform.GetComponent<Renderer> ().material.color = Color.blue;
		} else if (transform.GetComponent<Renderer> ().material.color == Color.cyan) {
			transform.GetComponent<Renderer> ().material.color = Color.magenta;
		} else if (transform.GetComponent<Renderer> ().material.color == Color.red) {
			transform.GetComponent<Renderer> ().material.color = Color.cyan;
		}
		else if (transform.GetComponent<Renderer> ().material.color == Color.gray) {
			transform.GetComponent<Renderer> ().material.color = Color.red;
		}
		//Debug.Log ("my position is (" + gridPosition.x +","+gridPosition.y+")");
	}

	void OnMouseExit(){
		if (transform.GetComponent<Renderer> ().material.color == Color.blue && !impassible) {
			transform.GetComponent<Renderer> ().material.color = Color.white;
		} else if(transform.GetComponent<Renderer> ().material.color == Color.magenta)
		{
			transform.GetComponent<Renderer> ().material.color = Color.cyan;
		}else if(transform.GetComponent<Renderer> ().material.color == Color.cyan){
			transform.GetComponent<Renderer> ().material.color = Color.red;
		}else if (transform.GetComponent<Renderer> ().material.color == Color.red) {
			transform.GetComponent<Renderer> ().material.color = Color.grey;
		}
	}

	void OnMouseUp() {
		if (GM.UserPlayers [GM.currentPlayerIndex].moving) {
			GM.moveCurrentPlayer (this);
			Debug.Log ("Wurde übergebn"+this.transform.position.x+","+this.transform.position.z);
		} else if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking) {
			GameManager.instance.attackWithCurrentPlayer(this);
			Debug.Log ("Angriff auf"+this.transform.position.x+","+this.transform.position.z);
	}
		else if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming) {
			GameManager.instance.aimWithCurrentPlayer(this);
			Debug.Log ("Aiming"+this.transform.position.x+","+this.transform.position.z);
		}else if(!GM.UserPlayers[GM.currentPlayerIndex].moving
		         &&!GM.UserPlayers[GM.currentPlayerIndex].attacking
		         &&!GM.UserPlayers[GM.currentPlayerIndex].aiming
		         &&GM.UserPlayers.Any(t=>t.gridPosition==this.gridPosition)
		         &&GM.UserPlayers[GM.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition)].HP>0){
			GameManager.instance.formerPlayerIndex=GameManager.instance.currentPlayerIndex;
			GM.UserPlayers[GM.currentPlayerIndex].selected=false;
			GM.currentPlayerIndex=GM.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition);
			GM.UserPlayers[GM.currentPlayerIndex].selected=true;
			Camermovement.instance.ChangeCamPosition();

		}
}

}