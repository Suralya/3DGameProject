using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool selected = false;
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;

	public int HP = 25;

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
		
	}
}
