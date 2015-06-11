using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public Waffe Weapon = new Waffe();

	public Vector2 gridPosition = Vector2.zero;

	public bool selected = false;
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;

	public bool moving=false;
	public bool attacking =false;


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
}