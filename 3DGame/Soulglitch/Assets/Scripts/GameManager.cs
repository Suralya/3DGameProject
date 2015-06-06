using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int maxrounds = 10;
	public int roundcount =0;
	public int mapSizeX = 28;
	public int mapSizeY = 27;

	public bool _userTurn = true;

	public GameObject TilePrefab;
	public List<Tile> map = new List<Tile> ();

	public List<Player> UserPlayers =new List<Player>();
	public List<Player> AIPlayers = new List<Player>();

	Tile temptile=new Tile();
	Player tempplayer=new Player();

	void Awake() {
		instance = this;
	}


	void Start () {
		findTiles ();
		for (int i=map.Count-1; i>=0; i--) {
			map[i].getNeighbors();
		}
		findUserPlayers ();
		findAIPlayers ();

		nextTurn();
	}
	

	void Update () {
		//wincheck ();

		if (_userTurn == true) {
			foreach (UserPlayer User in UserPlayers) {
				User.TurnUpdate ();
			}
		} else {
			foreach (AIPlayer AI in AIPlayers) {
				AI.TurnUpdate ();
			}

		}
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
		if (_userTurn) {
			UserTrun();

			//reset Userplayerpoints
			_userTurn=false;
		} else {
			UserPlayers.Find (delegate(Player obj) {
				return(obj.selected);
			}).selected = false;

			AITurn();
			removeTileHighlights();
			//reset AIPlayerpoints
			_userTurn = true;
			roundcount ++;
		}
	}

	public void UserTrun(){
		//Ablauf der Runde des Spielers
		Debug.Log ("It's your turn");
		UserPlayers [0].selected = true;
		//foreach (UserPlayer User in UserPlayers) {
		//	User.TurnUpdate ();
		//}

	}

	public void AITurn(){
		//Ablauf der Runde des Gegners
		Debug.Log ("It's the enemys turn");
	//	foreach (AIPlayer AI in AIPlayers) {
	//		AI.TurnUpdate ();
	//	}
		//nextTurn();
	}


	public void failcheck()
	{
		if (roundcount >= maxrounds) {
			//GameLost
			Debug.Log ("You Lost");
		}
	}


	public void wincheck(){
	//if all AIPlayer aus AIPlayers =dead - then spiel gewonnen
	}

	public void highlightTilesAt(Vector2 originLocation, Color highlightColor, int distance) {
		List <Tile> highlightedTiles = TileHighlight.FindHighlight(map.Find(delegate(Tile obj) {return(obj.gridPosition==originLocation);}), distance);
		
		foreach (Tile t in highlightedTiles) {
			t.transform.GetComponent<Renderer>().material.color = highlightColor;
		}
	}
	
	public void removeTileHighlights() {
			foreach(Tile obj in map)
				if (!obj.impassible) obj.transform.GetComponent<Renderer>().material.color = Color.white;
			}

	public void moveCurrentPlayer(Tile destTile) {
		if (destTile.transform.GetComponent<Renderer>().material.color != Color.white && !destTile.impassible) {
			removeTileHighlights();
			UserPlayers.Find(delegate(Player obj){return(obj.selected);}).moving = false;
			foreach(Tile t in TilePathFinder.FindPath(map.Find(delegate(Tile obj) {return(obj.gridPosition==UserPlayers.Find(delegate(Player obji){return(obji.selected);}).gridPosition);}),destTile)) {
				UserPlayers.Find(delegate(Player obj){return(obj.selected);}).positionQueue.Add(map.Find(delegate(Tile obj) {return(obj.gridPosition== t.gridPosition);}).transform.position + 1.5f * Vector3.up);
				Debug.Log("(" + UserPlayers.Find(delegate(Player obj){return(obj.selected);}).positionQueue[UserPlayers.Find(delegate(Player obj){return(obj.selected);}).positionQueue.Count - 1].x + "," + UserPlayers.Find(delegate(Player obj){return(obj.selected);}).positionQueue[UserPlayers.Find(delegate(Player obj){return(obj.selected);}).positionQueue.Count - 1].y + ")");
			}			
			UserPlayers.Find(delegate(Player obj){return(obj.selected);}).gridPosition = destTile.gridPosition;
		} else {
			Debug.Log ("destination invalid");
		}
	}

	public void selectSecond()
	{
		UserPlayers.Find (delegate(Player obj) {
			return(obj.selected);
		}).selected = false;

		UserPlayers [1].selected = true;
	}

}
