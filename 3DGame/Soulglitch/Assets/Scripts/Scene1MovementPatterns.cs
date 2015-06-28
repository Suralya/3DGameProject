using UnityEngine;
using System.Collections;

public class Scene1MovementPatterns : MovementPatterns {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void CivilianMove(){
		Debug.Log ("Civilian  movement");

	}

	public override void EnemyMove(){

		Debug.Log ("Enemy  movement");
	}
	
}
