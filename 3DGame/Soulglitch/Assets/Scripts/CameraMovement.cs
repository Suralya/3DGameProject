using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float _speedfactor=0.5f;
	public float StartSpeed=0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
			MoveUp ();

		if (Input.GetKey (KeyCode.S))
			MoveDown ();

		if (Input.GetKey (KeyCode.A))
			MoveRight ();

		if (Input.GetKey (KeyCode.D))
			MoveLeft ();

		if (!Input.anyKey) {_speedfactor = StartSpeed;}
		else {_speedfactor+=0.04f;}
	
	}

	private void MoveUp(){
		Vector3 temp = this.transform.position;
		temp.z+=1*_speedfactor;

		this.transform.position=temp;
	}
	private void MoveDown(){
		Vector3 temp = this.transform.position;
		temp.z-=1*_speedfactor;
		
		this.transform.position=temp;
	}
	private void MoveRight(){
		Vector3 temp = this.transform.position;
		temp.x-=1*_speedfactor;
		
		this.transform.position=temp;
	}
	private void MoveLeft(){
		Vector3 temp = this.transform.position;
		temp.x+=1*_speedfactor;
		
		this.transform.position=temp;
	}
	private void MoveUpRight(){
		Vector3 temp = this.transform.position;
		temp.z-=1*_speedfactor;
		temp.x-=1*_speedfactor;
		this.transform.position=temp;
	}
	private void MoveUpLeft(){
		Vector3 temp = this.transform.position;
		temp.z-=1*_speedfactor;
		temp.x+=1*_speedfactor;
		this.transform.position=temp;
	}
	private void MoveDownRight(){
		Vector3 temp = this.transform.position;
		temp.z+=1*_speedfactor;
		temp.x-=1*_speedfactor;
		this.transform.position=temp;
	}
	private void MoveDownLeft(){
		Vector3 temp = this.transform.position;
		temp.z+=1*_speedfactor;
		temp.x+=1*_speedfactor;
		this.transform.position=temp;
	}
}
