using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Player : MonoBehaviour {

	public Waffe Weapon = new Waffe();

	public Vector2 gridPosition = Vector2.zero;

	public bool selected = false;
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;

	public bool moving=false;
	public bool attacking =false;
	public bool aiming=false;


	public string playerName = "Robin";
	public int HP = 25;

	public int actionPoints = 20;


	public List<Vector3> positionQueue = new List<Vector3>();	
	
	void Awake () {
		moveDestination = transform.position;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public virtual void TurnUpdate () {
		if (actionPoints <= 0) {
			moving = false;
			attacking = false;
			
	}
}

	void OnMouseDown(){

		if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking) {
			GameManager.instance.attackWithCurrentPlayer(GameManager.instance.map.Find(t=> t.gridPosition==this.gridPosition));
			Debug.Log ("Angriff auf"+this.transform.position.x+","+this.transform.position.z);
		}
		else if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming) {
			GameManager.instance.aimWithCurrentPlayer(GameManager.instance.map.Find(t=> t.gridPosition==this.gridPosition));
			Debug.Log ("Aiming"+this.transform.position.x+","+this.transform.position.z);
		}else if(!GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
		   &&!GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
		   &&!GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
		   &&GameManager.instance.UserPlayers[GameManager.instance.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition)].HP>0
		   &&GameManager.instance.UserPlayers.Any(t=>t.gridPosition==this.gridPosition)){
			GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].selected=false;
			GameManager.instance.currentPlayerIndex=GameManager.instance.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition);
			GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].selected=true;
			
		}
	}
}