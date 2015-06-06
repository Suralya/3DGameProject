using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public Vector2 gridPosition = Vector2.zero;
	public string playerName ="Bob";
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;

	public int HP = 25;
	public int AP = 5;

	public int attackRange = 1;

	public bool moving = false;
	public bool attacking = false;
	public bool selected = false;

	//movement animation
	public List<Vector3> positionQueue = new List<Vector3>();


	void Awake () {
		moveDestination = transform.position;
	}
	// Use this for initialization
	void Start () {
		gridPosition.x = this.transform.position.x;
		gridPosition.y = this.transform.position.z;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void TurnUpdate()
	{
		moving = false;
		attacking = false;	
	}
}
