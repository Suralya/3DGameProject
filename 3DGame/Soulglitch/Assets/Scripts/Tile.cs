using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {

	public Vector2 gridPosition = Vector2.zero;

	public int ACost = 1;
	public bool impassible = false;
	
	public List<Tile> neighbors = new List<Tile>();

	public GameManager GM ;

	// Use this for initialization
	void Start () {
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
	void OnMouseEnter(){
		transform.GetComponent<Renderer> ().material.color = Color.blue;
		Debug.Log ("my position is (" + gridPosition.x +","+gridPosition.y+")");
	}

	void OnMouseExit(){
		transform.GetComponent<Renderer>().material.color = Color.white;
	}

}