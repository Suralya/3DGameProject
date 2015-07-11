using UnityEngine;
using System.Collections;

public class MovementPatterns : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void CivilianMove(AIPlayer p){
		Debug.Log ("Civilian  movement");
	}
	
	public virtual void EnemyMove(AIPlayer p){
		Debug.Log ("Enemy movement");
	}
}
