using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public int mapSizeX = 28;
	public int mapSizeY = 27;

	public GameObject TilePrefab;
	public List<Tile> map = new List<Tile> ();
	public List<Player> UserPlayers =new List<Player>();
	public List<Player> AIPlayers = new List<Player>();

	Tile temptile;
	Player tempplayer;

	public bool _userturn =true;

	public int currentPlayerIndex = 0;

	void Awake() {
		instance = this;
	}
	// Use this for initialization
	void Start () {
		findTiles ();
		for (int i=map.Count-1; i>=0; i--) {
			map[i].getNeighbors();
		}

		//findUserPlayers ();
		findAIPlayers ();

		UserPlayers [0].selected = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (_userturn) {
			currentPlayerIndex = UserPlayers.FindIndex(delegate(Player obj) {return obj.selected;});
			UserPlayers [currentPlayerIndex].TurnUpdate ();
		} else {
			AIPlayers [currentPlayerIndex].TurnUpdate ();
		}
	}

	public void moveCurrentPlayer(Tile destTile) {
		if (_userturn) {

				if (destTile.transform.GetComponent<Renderer>().material.color != Color.white && !destTile.impassible) {
					removeTileHighlights ();
		
					foreach (Tile t in TilePathFinder.FindPath(map.Find(delegate(Tile obj) {return obj.gridPosition == UserPlayers[currentPlayerIndex].gridPosition;}),destTile)) {
					UserPlayers [currentPlayerIndex].positionQueue.Add (map.Find (delegate(Tile obj) {return obj.gridPosition == t.gridPosition;}).transform.position + 1.5f * Vector3.up);
						Debug.Log ("(" + UserPlayers [currentPlayerIndex].positionQueue [UserPlayers [currentPlayerIndex].positionQueue.Count - 1].x + "," + UserPlayers [currentPlayerIndex].positionQueue [UserPlayers [currentPlayerIndex].positionQueue.Count - 1].y + ")");
					}			
					UserPlayers [currentPlayerIndex].gridPosition = destTile.gridPosition;

					movePlayer();
					
				} else {
					Debug.Log ("destination invalid");
				}



		}
	}

	public void movePlayer(){
		if (_userturn) {


			if(!UserPlayers[currentPlayerIndex].moving)
			{
				UserPlayers[currentPlayerIndex].gridPosition.x=UserPlayers[currentPlayerIndex].transform.position.x;
				UserPlayers[currentPlayerIndex].gridPosition.y=UserPlayers[currentPlayerIndex].transform.position.z;


				Debug.Log("get movin'");
				removeTileHighlights ();
				UserPlayers[currentPlayerIndex].moving=true;
				UserPlayers[currentPlayerIndex].attacking=false;
				highlightTilesAt(UserPlayers[currentPlayerIndex].gridPosition, Color.cyan, UserPlayers[currentPlayerIndex].movementPerActionPoint);

				
			}else{
				Debug.Log("no movin' today ");
				UserPlayers[currentPlayerIndex].moving=false;
				UserPlayers[currentPlayerIndex].attacking=false;
				removeTileHighlights ();
			}
			
		}
	}

	public void attackPlayer(){
		if (_userturn) {
			
			if(!UserPlayers[currentPlayerIndex].attacking)
			{
				removeTileHighlights ();
				Debug.Log("start attack'");
				UserPlayers[currentPlayerIndex].attacking=true;
				UserPlayers[currentPlayerIndex].moving=false;
				
				
				
			}else{
				Debug.Log("no attack");
				UserPlayers[currentPlayerIndex].attacking=false;
				UserPlayers[currentPlayerIndex].moving=false;
				removeTileHighlights ();
			}
			
		}
	}



	public void nextTurn()
	{
		if (!_userturn) {
			//userturn
			_userturn =true;
			Debug.Log("It's your turn");
			UserPlayers [currentPlayerIndex].selected =false;
			currentPlayerIndex = 0;
			UserPlayers [currentPlayerIndex].selected =true;
		} else {
			removeTileHighlights ();
			foreach(Player User in UserPlayers)
			{
				User.actionPoints=2;
			}
			//AIturn
			_userturn =false;
			Debug.Log("It's the enemys turn");
			currentPlayerIndex = 0;
		}
	}

	public void selectFirst (){
	if (_userturn) {
		
			UserPlayers [currentPlayerIndex].selected =false;
			UserPlayers [0].selected =true;
		
		}
	}
	public void selectSecond (){
		if (_userturn) {
			
			UserPlayers [currentPlayerIndex].selected =false;
			UserPlayers [1].selected =true;
			
		}
	}
	public void selectThird (){
		if (_userturn) {
			
			UserPlayers [currentPlayerIndex].selected =false;
			UserPlayers [2].selected =true;
			
		}
	}
	public void selectFourth (){
		if (_userturn) {
			
			UserPlayers [currentPlayerIndex].selected =false;
			UserPlayers [3].selected =true;
			
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


	public void highlightTilesAt(Vector2 originLocation, Color highlightColor, int distance) {
		List <Tile> highlightedTiles = TileHighlight.FindHighlight(map.Find(delegate(Tile obj) {return obj.gridPosition==originLocation;}), distance);
		
		foreach (Tile t in highlightedTiles) {
			t.transform.GetComponent<Renderer>().material.color = highlightColor;
		}
	}

	public void removeTileHighlights() {
		
		foreach (Tile t in map) {
			if(!t.impassible){
				t.transform.GetComponent<Renderer>().material.color = Color.white;
			}
		}
	}


}
