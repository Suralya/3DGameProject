using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public int maxrounds = 10;
	public int roundcount =0;
	public int mapSizeX = 28;
	public int mapSizeY = 27;

	public bool UserTurn = true;

	public GameObject TilePrefab;
	public List<Tile> map = new List<Tile> ();

	public List<Player> UserPlayers =new List<Player>();
	public List<Player> AIPlayers = new List<Player>();

	Tile temptile=new Tile();
	Player tempplayer=new Player();
	
	void Start () {
		findTiles ();
		for (int i=map.Count-1; i>=0; i--) {
			map[i].getNeighbors();
		}
		findUserPlayers ();
		findAIPlayers ();
	}
	

	void Update () {
		//wincheck ();
	}

	public void findTiles(){
		var temp = GameObject.FindGameObjectsWithTag ("Tile");
		for (int i= temp.Length-1; i>=0; i--) {

			temptile= temp[i].GetComponent<Tile>();
			map.Add (temptile);
		}
	}


	public void findUserPlayers(){
		var temp = GameObject.FindGameObjectsWithTag ("UserPlayer");
		for (int i= temp.Length-1; i>=0; i--) {
			
			tempplayer= temp[i].GetComponent<UserPlayer>();
			UserPlayers.Add (tempplayer);
		}
	}


	public void findAIPlayers(){
		var temp = GameObject.FindGameObjectsWithTag ("AIPlayer");
		for (int i= temp.Length-1; i>=0; i--) {
			
			tempplayer= temp[i].GetComponent<AIPlayer>();
			AIPlayers.Add (tempplayer);
		}
	}


	public void nextTurn() {
		failcheck ();
		if (UserTurn) {
			//reset Userplayerpoints
			UserTurn=false;
		} else {
			//reset AIPlayerpoints
			UserTurn = true;
			roundcount ++;
		}
	}


	public void failcheck()
	{
		if (roundcount >= maxrounds) {
			//GameLost
		}
	}


	public void wincheck(){
	//if all AIPlayer aus AIPlayers =dead - then spiel gewonnen
	}
}
