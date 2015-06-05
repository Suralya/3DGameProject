using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public int mapSizeX = 28;
	public int mapSizeY = 27;

	public GameObject TilePrefab;
	public List<Tile> map = new List<Tile> ();

	public List<Player> userplayers =new List<Player>();
	public List<Player> enemyplayer = new List<Player>();

	Tile temptile=new Tile();

	// Use this for initialization
	void Start () {
		findTiles ();
		for (int i=map.Count-1; i>=0; i--) {
			map[i].getNeighbors();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void findTiles(){
		var temp = GameObject.FindGameObjectsWithTag ("Tile");
		for (int i= temp.Length-1; i>=0; i--) {

			temptile= temp[i].GetComponent<Tile>();
			map.Add (temptile);
		}
	}
}
