using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public MovementPatterns SceneMovePatern;

	public int mapSizeX = 28;
	public int mapSizeY = 27;

	public GameObject TilePrefab;
	public List<Tile> map = new List<Tile> ();
	public List<Player> UserPlayers =new List<Player>();
	public List<Player> AIPlayers = new List<Player>();

	public Canvas Tooltipcanvas;
	public bool Tooltipshown =true;
	public Text Tooltiptext;

	public Canvas Questlogcanvas;
	public bool Questlogshown =false;
	public Text Questlogtext;

	Tile temptile;
	Player tempplayer;

	public bool _userturn =true;

	public int formerPlayerIndex=0;
	public int currentPlayerIndex = 0;

	void Awake() {
		instance = this;
	}
	// Use this for initialization
	void Start () {
		Questlogcanvas.enabled=false;

		findTiles ();
		for (int i=map.Count-1; i>=0; i--) {
			map[i].getNeighbors();
		}

		//findUserPlayers ();  -set by scene
		findAIPlayers ();

		UserPlayers [0].selected = true;

		var temp = GameObject.FindGameObjectWithTag ("Tooltip");
		Tooltiptext = temp.GetComponent<Text>();

		Comments.instance.MakeComment ("Assets/Texts/Comment_Leader_01_de.txt"); //wird nur Gezeigt wenn in Szene Gestartet wird
	}
	
	// Update is called once per frame
	void Update () {
		if (_userturn) {
			currentPlayerIndex = UserPlayers.FindIndex(delegate(Player obj) {return obj.selected;});
		} else if (!_userturn){

			//AIPlayers [currentPlayerIndex].TurnUpdate ();
			
			foreach(Player p in AIPlayers)
			{p.TurnUpdate ();}
		}

		foreach(Player p in UserPlayers)
		{p.TurnUpdate ();}


	    if (UserPlayers[currentPlayerIndex].moving)
	    {
            Tooltiptext.text = "Deine Bewegung kostet: "+" AP";
	    }

	}


	/// <summary>
	/// Shows or hides the tooltip.
	/// </summary>
	public void showhideTooltip(){
		if (Tooltipshown) {
			Tooltipshown = false;
			Tooltipcanvas.enabled = false;
		} else {
			Tooltipshown = true;
			Tooltipcanvas.enabled = true;
		}
	}
		/// <summary>
		/// Shows or hides the Questlog.
		/// </summary>

		public void showhideQuestlog(){
		if (Questlogshown) {
			Questlogshown=false;
			Questlogcanvas.enabled=false;
		} else {Questlogshown=true;
			Questlogcanvas.enabled=true;
			}
	
	}

	/// <summary>
	/// Moves the current player.
	/// </summary>
	/// <param name="destTile">Selected tile.</param>
	public void moveCurrentPlayer(Tile destTile) {
		if (_userturn) {

				if (destTile.transform.GetComponent<Renderer>().material.color == Color.magenta && !destTile.impassible && !destTile.occupied) {
					removeTileHighlights ();

				UserPlayers[currentPlayerIndex].ActionPoints -= TilePathFinder.FindPath(map.Find(t => t.gridPosition==UserPlayers[currentPlayerIndex].gridPosition),destTile).Count;
				
				foreach (Tile t in TilePathFinder.FindPath(map.Find(t => t.gridPosition==UserPlayers[currentPlayerIndex].gridPosition),destTile)) {
					UserPlayers [currentPlayerIndex].positionQueue.Add (map.Find (delegate(Tile obj) {return obj.gridPosition == t.gridPosition;}).transform.position +Vector3.up);
						Debug.Log ("(" + UserPlayers [currentPlayerIndex].positionQueue [UserPlayers [currentPlayerIndex].positionQueue.Count - 1].x + "," + UserPlayers [currentPlayerIndex].positionQueue [UserPlayers [currentPlayerIndex].positionQueue.Count - 1].y + ")");
					}			
					UserPlayers [currentPlayerIndex].gridPosition = destTile.gridPosition;
				   

					movePlayer();
				    //StartCoroutine(Waittillmoved());

				} else {
					Debug.Log ("destination invalid");
				}



		}
	}

    public IEnumerator Waittillmoved()
    {
        yield return new WaitForSeconds(0.5f);
        movePlayer();
    }

    /// <summary>
	/// Attacks the with current player.
	/// </summary>
	/// <param name="destTile">Selected tile.</param>

	public void attackWithCurrentPlayer(Tile destTile) {
		if (!UserPlayers [currentPlayerIndex].Weapon.healing) {

			if (destTile.transform.GetComponent<Renderer> ().material.color != Color.white && !destTile.impassible) {
			
				Player target = null;
				foreach (Player p in AIPlayers) {
					if (p.gridPosition == destTile.gridPosition) {
						target = p;
					}
				}
			
				if (target != null && target.HP > 0) {


				
					//Debug.Log ("p.x: " + players[currentPlayerIndex].gridPosition.x + ", p.y: " + players[currentPlayerIndex].gridPosition.y + " t.x: " + target.gridPosition.x + ", t.y: " + target.gridPosition.y);
					if (UserPlayers [currentPlayerIndex].gridPosition.x >= target.gridPosition.x - UserPlayers [currentPlayerIndex].Weapon.Attackrange && UserPlayers [currentPlayerIndex].gridPosition.x <= target.gridPosition.x + UserPlayers [currentPlayerIndex].Weapon.Attackrange &&
						UserPlayers [currentPlayerIndex].gridPosition.y >= target.gridPosition.y - UserPlayers [currentPlayerIndex].Weapon.Attackrange && UserPlayers [currentPlayerIndex].gridPosition.y <= target.gridPosition.y + UserPlayers [currentPlayerIndex].Weapon.Attackrange) {
						UserPlayers [currentPlayerIndex].ActionPoints -= UserPlayers [currentPlayerIndex].Weapon.APCost;
					
						removeTileHighlights ();
						UserPlayers [currentPlayerIndex].moving = false;			
					
						//attack logic
						//roll to hit
						bool hit = Random.Range (0.0f, 1.0f) <= UserPlayers [currentPlayerIndex].Weapon.Hitchance;

						Vector3 targetpos = target.transform.position;
						targetpos -= UserPlayers [currentPlayerIndex].transform.position;
						RaycastHit hittarget;

						Physics.Raycast (UserPlayers [currentPlayerIndex].transform.position, targetpos, out hittarget);


						if (hittarget.collider.gameObject.GetComponent<Player> () != null && hit && hittarget.collider.gameObject.GetComponent<Player> ().Equals (target)) {

							//damage logic
							int amountOfDamage = (int)Mathf.Floor (UserPlayers [currentPlayerIndex].Weapon.Damage/* + Random.Range(0, UserPlayers[currentPlayerIndex].damageRollSides)*/);
						
							target.HP -= amountOfDamage;
							hittarget.collider.gameObject.transform.DOShakeRotation (0.5f, 45f, 50, 90);
						
							Debug.Log (UserPlayers [currentPlayerIndex].playerName + " successfuly hit " + target.playerName + " for " + amountOfDamage + " damage!");
						} else {
							Debug.Log (UserPlayers [currentPlayerIndex].playerName + " missed " + target.playerName + "!");
						}
						attackPlayer ();
					} else {
						Debug.Log ("Target is not adjacent!");
					}
				
				} else {
					Debug.Log ("destination invalid");
				}
			}
		} else {
			
			if (destTile.transform.GetComponent<Renderer> ().material.color != Color.white && !destTile.impassible) {
				
				Player target = null;
				foreach (Player p in UserPlayers) {
					if (p.gridPosition == destTile.gridPosition) {
						target = p;
					}
				}
				
				if (target != null && target!=UserPlayers[currentPlayerIndex] && target.HP > 0) {
					
					
					
					//Debug.Log ("p.x: " + players[currentPlayerIndex].gridPosition.x + ", p.y: " + players[currentPlayerIndex].gridPosition.y + " t.x: " + target.gridPosition.x + ", t.y: " + target.gridPosition.y);
					if (UserPlayers [currentPlayerIndex].gridPosition.x >= target.gridPosition.x - UserPlayers [currentPlayerIndex].Weapon.Attackrange && UserPlayers [currentPlayerIndex].gridPosition.x <= target.gridPosition.x + UserPlayers [currentPlayerIndex].Weapon.Attackrange &&
					    UserPlayers [currentPlayerIndex].gridPosition.y >= target.gridPosition.y - UserPlayers [currentPlayerIndex].Weapon.Attackrange && UserPlayers [currentPlayerIndex].gridPosition.y <= target.gridPosition.y + UserPlayers [currentPlayerIndex].Weapon.Attackrange) {
						UserPlayers [currentPlayerIndex].ActionPoints -= UserPlayers [currentPlayerIndex].Weapon.APCost;
						
						removeTileHighlights ();
						UserPlayers [currentPlayerIndex].moving = false;			
						
						//attack logic
						//roll to hit
						bool hit = Random.Range (0.0f, 1.0f) <= UserPlayers [currentPlayerIndex].Weapon.Hitchance;
						
						Vector3 targetpos = target.transform.position;
						targetpos -= UserPlayers [currentPlayerIndex].transform.position;
						RaycastHit hittarget;
						
						Physics.Raycast (UserPlayers [currentPlayerIndex].transform.position, targetpos, out hittarget);
						
						
						if (hittarget.collider.gameObject.GetComponent<Player> () != null && hit && hittarget.collider.gameObject.GetComponent<Player> ().Equals (target)) {
							
							//damage logic
							int amountOfDamage = (int)Mathf.Floor (UserPlayers [currentPlayerIndex].Weapon.Damage/* + Random.Range(0, UserPlayers[currentPlayerIndex].damageRollSides)*/);

							if(target.HP-amountOfDamage>target.MaxHP)
								target.HP=target.MaxHP;
							else{target.HP -= amountOfDamage;}

							hittarget.collider.gameObject.transform.DOJump(target.transform.position,2f,2,0.5f);
							
							Debug.Log (UserPlayers [currentPlayerIndex].playerName + " successfuly healed " + target.playerName + " " + amountOfDamage*(-1) + " HP!");
						} else {
							Debug.Log (UserPlayers [currentPlayerIndex].playerName + " wasn't able to heal " + target.playerName + "!");
						}
						attackPlayer ();
					} else {
						Debug.Log ("Target is not adjacent!");
					}
					
				} else {
					Debug.Log ("destination invalid");
				}

			}
		}
	}




	/// <summary>
	/// Aims the with current player.
	/// </summary>
	/// <param name="destTile">Selected tile.</param>

	public void aimWithCurrentPlayer(Tile destTile){

		if (destTile.transform.GetComponent<Renderer> ().material.color != Color.white && !destTile.impassible) {
			
			Player target = null;
			foreach (Player p in AIPlayers) {
				if (p.gridPosition == destTile.gridPosition) {
					target = p;
				}
			}
			
			if (target != null&&target.HP>0) {

				
				
				//Debug.Log ("p.x: " + players[currentPlayerIndex].gridPosition.x + ", p.y: " + players[currentPlayerIndex].gridPosition.y + " t.x: " + target.gridPosition.x + ", t.y: " + target.gridPosition.y);
				if (UserPlayers [currentPlayerIndex].gridPosition.x >= target.gridPosition.x - UserPlayers [currentPlayerIndex].Weapon.Attackrange && UserPlayers [currentPlayerIndex].gridPosition.x <= target.gridPosition.x + UserPlayers [currentPlayerIndex].Weapon.Attackrange &&
				    UserPlayers [currentPlayerIndex].gridPosition.y >= target.gridPosition.y - UserPlayers [currentPlayerIndex].Weapon.Attackrange && UserPlayers [currentPlayerIndex].gridPosition.y <= target.gridPosition.y + UserPlayers [currentPlayerIndex].Weapon.Attackrange) 
				{
					UserPlayers [currentPlayerIndex].ActionPoints -= 1;
					
					removeTileHighlights ();
					UserPlayers [currentPlayerIndex].moving = false;			
					
					Vector3 targetpos=target.transform.position;
					targetpos-=UserPlayers[currentPlayerIndex].transform.position;
					RaycastHit hittarget;
					
					Physics.Raycast(UserPlayers[currentPlayerIndex].transform.position,targetpos,out hittarget);


                    if (hittarget.collider.gameObject.GetComponent<Player>() != null && hittarget.collider.gameObject.GetComponent<Player>().Equals(target))
                    {
						
						Debug.Log (UserPlayers [currentPlayerIndex].playerName + " can hit " + target.playerName+"!");
					} else {
						Debug.Log (UserPlayers [currentPlayerIndex].playerName + " will miss " + target.playerName + "!");
					}
					aimPlayer();
				} else {
					Debug.Log ("Target is not adjacent!");
				}
				
			} else {
				Debug.Log ("destination invalid");
			}
		}

	}

	/// <summary>
	/// Enables Movement and showes Tiles to move to(cyan)//disables if already enabled.
	/// </summary>

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
				UserPlayers[currentPlayerIndex].aiming=false;
				highlightTilesAt(UserPlayers[currentPlayerIndex].gridPosition, Color.blue, UserPlayers[currentPlayerIndex].ActionPoints);

				Tooltiptext.text=System.IO.File.ReadAllText("Assets/Texts/Tooltip_move_de.txt");

				
			}else{
				Debug.Log("no movin' today ");
				UserPlayers[currentPlayerIndex].moving=false;
				UserPlayers[currentPlayerIndex].attacking=false;
				UserPlayers[currentPlayerIndex].aiming=false;
				removeTileHighlights ();

				Tooltiptext.text=" ";
			}
			
		}
	}

	/// <summary>
	/// Weaponchange this instance.
	/// </summary>

	public void weaponchange()
	{
		if (UserPlayers [currentPlayerIndex].CurrentWeaponisOne) {
			UserPlayers [currentPlayerIndex].Weapon = UserPlayers [currentPlayerIndex].OwnedWeapons [1];
			UserPlayers [currentPlayerIndex].CurrentWeaponisOne = false;
		} else {			
			UserPlayers [currentPlayerIndex].Weapon = UserPlayers [currentPlayerIndex].OwnedWeapons [0];
			UserPlayers [currentPlayerIndex].CurrentWeaponisOne = true;
		}

		UserPlayers[currentPlayerIndex].attacking=false;
		UserPlayers[currentPlayerIndex].moving=false;
		UserPlayers[currentPlayerIndex].aiming=false;
		removeTileHighlights ();
		Tooltiptext.text=" ";

		Debug.Log("weapon changed ");
	}

	/// <summary>
	/// Enables Attacking Enemys and shows Tiles in range(red)// Disables if already enabled.
	/// </summary>

	public void attackPlayer(){
		if (_userturn) {
			if(!UserPlayers[currentPlayerIndex].attacking)
			{
			if (UserPlayers [currentPlayerIndex].ActionPoints >= UserPlayers [currentPlayerIndex].Weapon.APCost)	
			{
				Comments.instance.MakeComment (UserPlayers[currentPlayerIndex].Avatar, "Assets/Texts/Comment_All_attack_de.txt");
				removeTileHighlights ();
				Debug.Log("start attack'");
				UserPlayers[currentPlayerIndex].attacking=true;
				UserPlayers[currentPlayerIndex].moving=false;
				UserPlayers[currentPlayerIndex].aiming=false;
					if(!UserPlayers[currentPlayerIndex].Weapon.healing)
					{GameManager.instance.highlightAtackTilesAt(UserPlayers[currentPlayerIndex].gridPosition, Color.red, UserPlayers[currentPlayerIndex].Weapon.Attackrange);
					Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_attack_de.txt")+UserPlayers [currentPlayerIndex].Weapon.APCost;
					}else{
						GameManager.instance.highlightAtackTilesAt(UserPlayers[currentPlayerIndex].gridPosition, Color.yellow, UserPlayers[currentPlayerIndex].Weapon.Attackrange);
						Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_attack_de.txt")+UserPlayers [currentPlayerIndex].Weapon.APCost;
					}
				} else {
					Debug.Log ("nicht genug AP");
					Tooltiptext.text="Du hast nicht genug AP um einen Angriff zu machen";
				}
				
			}else{
				Debug.Log("no attack");
				UserPlayers[currentPlayerIndex].attacking=false;
				UserPlayers[currentPlayerIndex].moving=false;
				UserPlayers[currentPlayerIndex].aiming=false;
				removeTileHighlights ();
				Tooltiptext.text=" ";
			}
			
		}
	}

	/// <summary>
	/// Enables aiming Enemys and shows Tiles in range(red)// Disables if already enabled.
	/// </summary>
	public void aimPlayer(){
		if (_userturn) {
			
			if(!UserPlayers[currentPlayerIndex].aiming)
			{
				if (UserPlayers [currentPlayerIndex].ActionPoints >= 1)
					
				{
					removeTileHighlights ();
					Debug.Log("Aim");
					UserPlayers[currentPlayerIndex].attacking=false;
					UserPlayers[currentPlayerIndex].moving=false;
					UserPlayers[currentPlayerIndex].aiming=true;
					GameManager.instance.highlightAtackTilesAt(UserPlayers[currentPlayerIndex].gridPosition, Color.magenta, UserPlayers[currentPlayerIndex].Weapon.Attackrange);

					Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_aim_de.txt");
					
				} else {
					Debug.Log ("nicht genug AP");
					Tooltiptext.text="Du hast nicht genug AP";
				}
				
			}else{
				Debug.Log("not aiming");
				UserPlayers[currentPlayerIndex].attacking=false;
				UserPlayers[currentPlayerIndex].moving=false;
				UserPlayers[currentPlayerIndex].aiming=false;
				removeTileHighlights ();
				Tooltiptext.text=" ";
			}
			
		}

	
	}

	/// <summary>
	/// Ends current Turn (Userturn or AIPlayerturn) and starts the others. 
	/// </summary>
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
		/*	removeTileHighlights ();
			foreach(Player User in UserPlayers)
			{
				User.ActionPoints=20;
			}
			//AIturn
			_userturn =false;
			Debug.Log("It's the enemys turn");

			currentPlayerIndex = 0;
			Tooltiptext.text=" ";

			foreach (Player p in AIPlayers){				
				yield return new WaitForSeconds(1f);
				p.AIMove();}*/

			StartCoroutine(AITurn());


			
		}
	}
	// THOMAS FRAGEN FÜRS WARTEN!!!!!
	public IEnumerator AITurn(){

		removeTileHighlights ();
		foreach(Player User in UserPlayers)
		{
			User.ActionPoints=(int)User.MaxAP;
		}
		//AIturn
		_userturn =false;
		Debug.Log("It's the enemys turn");
		
		currentPlayerIndex = 0;
		Tooltiptext.text=" ";
		
		foreach (Player p in AIPlayers) {		
			if (p.HP > 0) {
				yield return new WaitForSeconds (1f);
				p.AIMove ();
			}
		}
			
			nextTurn();
		}

	

	/// <summary>
	/// Selects the first Player of Userplayers.
	/// </summary>
	public void selectFirst (){
	if (_userturn) {
			formerPlayerIndex=currentPlayerIndex;
			UserPlayers[currentPlayerIndex].attacking=false;
			UserPlayers[currentPlayerIndex].moving=false;
			UserPlayers[currentPlayerIndex].aiming=false;
			removeTileHighlights ();
			Tooltiptext.text=" ";
		
			UserPlayers [currentPlayerIndex].selected =false;
			UserPlayers [0].selected =true;
			currentPlayerIndex = UserPlayers.FindIndex(delegate(Player obj) {return obj.selected;});
			CameraCenteronCurrent.instance.CamonCurent();

		}
	}

	/// <summary>
	/// Selects the second Player of Userplayers.
	/// </summary>
	public void selectSecond (){
		if (_userturn) {
			formerPlayerIndex=currentPlayerIndex;
			UserPlayers[currentPlayerIndex].attacking=false;
			UserPlayers[currentPlayerIndex].moving=false;
			UserPlayers[currentPlayerIndex].aiming=false;
			removeTileHighlights ();
			Tooltiptext.text=" ";
			
			UserPlayers [currentPlayerIndex].selected =false;
			UserPlayers [1].selected =true;
			currentPlayerIndex = UserPlayers.FindIndex(delegate(Player obj) {return obj.selected;});
			CameraCenteronCurrent.instance.CamonCurent();

		}

	}

	/// <summary>
	/// Selects the third Player of Userplayers.
	/// </summary>
	public void selectThird (){
		if (_userturn) {
			formerPlayerIndex=currentPlayerIndex;
			UserPlayers[currentPlayerIndex].attacking=false;
			UserPlayers[currentPlayerIndex].moving=false;
			UserPlayers[currentPlayerIndex].aiming=false;
			removeTileHighlights ();
			Tooltiptext.text=" ";
			
			UserPlayers [currentPlayerIndex].selected =false;
			UserPlayers [2].selected =true;
			currentPlayerIndex = UserPlayers.FindIndex(delegate(Player obj) {return obj.selected;});
			CameraCenteronCurrent.instance.CamonCurent();
		}
	}

	/// <summary>
	/// Selects the fourth Player of Userplayers.
	/// </summary>
	public void selectFourth (){
		if (_userturn) {
			formerPlayerIndex=currentPlayerIndex;
			UserPlayers[currentPlayerIndex].attacking=false;
			UserPlayers[currentPlayerIndex].moving=false;
			UserPlayers[currentPlayerIndex].aiming=false;
			removeTileHighlights ();
			Tooltiptext.text=" ";
			
			UserPlayers [currentPlayerIndex].selected =false;
			UserPlayers [3].selected =true;
			currentPlayerIndex = UserPlayers.FindIndex(delegate(Player obj) {return obj.selected;});
			CameraCenteronCurrent.instance.CamonCurent();
		}
	}

	/// <summary>
	/// Finds all tiles in Scene.
	/// </summary>
	public void findTiles(){
		var temp = GameObject.FindGameObjectsWithTag ("Tile");
		for (int i= temp.Length-1; i>=0; i--) {

			temptile= temp[i].GetComponent<Tile>();
			map.Add (temptile);
		}
	}

	/// <summary>
	/// Finds the user players.
	/// </summary>
	public void findUserPlayers(){
		var temp = GameObject.FindGameObjectsWithTag ("UserPlayer");
		for (int i= temp.Length-1; i>=0; i--) {
			
			tempplayer= temp[i].GetComponent<UserPlayer>();
			UserPlayers.Add (tempplayer);
		}
	}

	/// <summary>
	/// Finds the AI players.
	/// </summary>
	public void findAIPlayers(){
		var temp = GameObject.FindGameObjectsWithTag ("AIPlayer");
		for (int i= temp.Length-1; i>=0; i--) {
			
			tempplayer= temp[i].GetComponent<AIPlayer>();
			AIPlayers.Add (tempplayer);
		}
	}

	/// <summary>
	/// Highlights the atack tiles at originLocation, in highlightColor and distance.
	/// </summary>
	/// <param name="originLocation">Location of selected Player.</param>
	/// <param name="highlightColor">Highlight color.</param>
	/// <param name="distance">Range in which attack is possible.</param>
	public void highlightAtackTilesAt(Vector2 originLocation, Color highlightColor, int distance) {
		List <Tile> highlightedTiles = TileHighlight.FindAtackHighlight(map.Find(delegate(Tile obj) {return obj.gridPosition==originLocation;}), distance);
		
		foreach (Tile t in highlightedTiles) {
			t.transform.GetComponent<Renderer>().material.color = highlightColor;
		}
	}

	/// <summary>
	/// Highlights the tiles at originLocation, in highlightColor and distance.
	/// </summary>
	/// <param name="originLocation">Origin location.</param>
	/// <param name="highlightColor">Highlight color.</param>
	/// <param name="distance">Possible Range to move</param>
	public void highlightTilesAt(Vector2 originLocation, Color highlightColor, int distance) {
		List <Tile> highlightedTiles = TileHighlight.FindHighlight(map.Find(delegate(Tile obj) {return obj.gridPosition==originLocation;}), distance);
		
		foreach (Tile t in highlightedTiles) {
			t.transform.GetComponent<Renderer>().material.color = highlightColor;
		}
	}

	/// <summary>
	/// Removes the tile highlights.
	/// </summary>
	public void removeTileHighlights() {
		
		foreach (Tile t in map) {
			if(!t.impassible||!t.occupied){
				t.transform.GetComponent<Renderer>().material.color = Color.white;
			}
		}
	}


}
