using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;

public class Scene1MovementPatterns : MovementPatterns {

	public List<Tile> Temp=new List<Tile>();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// Initiates Civil Move
	/// </summary>
	/// <param name="p">P.</param>
	public override void CivilianMove(AIPlayer p){
		bool TurnOn=true;
		while (!GameManager.instance._userturn&&TurnOn) {

		//	Debug.Log ("Civilian  movement");
			TurnOn=false;
		}

		p.ActionPoints = (int)p.MaxAP;

	}
/// <summary>
/// Initiates Enemy Move
/// </summary>
/// <param name="p">P.</param>
	public override void EnemyMove(AIPlayer p){
		//while (!GameManager.instance._userturn&&TurnOn) {


	//	Debug.Log ("Enemy  movement");

			List<Tile> attacktilesInRange = TileHighlight.FindAtackHighlight(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition), p.Weapon.Attackrange);
			//List<Tile> movementToAttackTilesInRange = TileHighlight.FindHighlight(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition),p.ActionPoints- p.Weapon.APCost+  p.Weapon.Attackrange);
			List<Tile> movementTilesInRange = TileHighlight.FindAIMoveHighlight(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition), p.ActionPoints+1000);







		//KI Attack if Enemy attackable, else Move 1

			if (attacktilesInRange.Where (x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y.gridPosition == x.gridPosition).Count () > 0).Count () > 0) {

			if(Random.Range(1,20)<=1)
				Comments.instance.MakeComment(p.playerName,p.Avatar,"Verschwinde von hier!");


			//if(attacktilesInRange.Count>0)
			Debug.Log ("Someone is in Range");
			var opponentsInRange = attacktilesInRange.Select (x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y.gridPosition == x.gridPosition).First () : null).ToList ();
			Player opponent = opponentsInRange.OrderBy (x => x != null ? -x.HP : 1000).First ();

			Debug.Log ("The Player in Range is" + opponent.name);



			if (AIBehave.instance.AIAim (opponent, p)) {
				while (p.ActionPoints>p.Weapon.APCost&&opponent.HP>0)
					AIBehave.instance.AIAttack (opponent, p);
			} else {
				//	GameManager.instance.removeTileHighlights();
				//	GameManager.instance.highlightTilesAt(p.gridPosition, Color.blue, p.ActionPoints);
				Debug.Log (p.playerName + " will zu " + opponent.name);
				List<Tile> path = TilePathFinder.FindAIPath (GameManager.instance.map.Find (i => i.gridPosition == p.gridPosition), GameManager.instance.map.Find (i => i.gridPosition == opponent.gridPosition)/*, GameManager.instance.UserPlayers.Where(x => x.gridPosition != p.gridPosition && x.gridPosition != opponent.gridPosition).Select(x => x.gridPosition).ToArray()*/);
				//TODO GameManager.instance.moveCurrentPlayer(path[(int)Mathf.Min(Mathf.Max (path.Count - 1 - 1, 0), movementPerActionPoint - 1)]);
				
				if (path.Count != null&&path.Count<26) {
					int indexer = 0;
					if (p.ActionPoints - 1 > 3) {
						indexer = (int)Mathf.Min (Mathf.Max (path.Count - 1 - 1, 0), 3);
					} else {
						indexer = (int)Mathf.Min (Mathf.Max (path.Count - 1 - 1, 0), p.ActionPoints - 1);
					}
					
					while (path[indexer].occupied) {
						indexer--;
						if (indexer <= 0) {
							indexer = 0;
							break;
						}
					}

					if (indexer > 0 && TilePathFinder.FindPath (GameManager.instance.map.Find (t => t.gridPosition == p.gridPosition), path [indexer]) != null) {
						AIBehave.instance.AIMove (path [indexer], p);
						Debug.Log ("ran");
						
						if (p.ActionPoints > p.Weapon.APCost) {
							//			if(opponent.HP>0)
							//		{AIBehave.instance.AIAttack (opponent, p);}
							//		else
							EnemyMove (p);
						}
					}

				}
			}


		} 






		//KI Move

		else if (movementTilesInRange.Where (x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0).Count () > 0) {

			if(Random.Range(1,10)<=1)
				Comments.instance.MakeComment(p.playerName,p.Avatar,"Dort ist Jemand!");

			var opponentsInRange = movementTilesInRange.Select (x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y.gridPosition == x.gridPosition).First () : null).ToList ();
			Player opponent = opponentsInRange.OrderBy (x => x != null ? -x.HP : 1000).ThenBy (x => x != null ? TilePathFinder.FindPath (GameManager.instance.map.Find (i => i.gridPosition == p.gridPosition), GameManager.instance.map.Find (i => i.gridPosition == p.gridPosition)).Count () : 1000).First ();
			
			//	GameManager.instance.removeTileHighlights();
			//	GameManager.instance.highlightTilesAt(p.gridPosition, Color.blue, p.ActionPoints);
			//Debug.Log (p.playerName + " will zu " + opponent.name);
			List<Tile> path = TilePathFinder.FindAIPath (GameManager.instance.map.Find (i => i.gridPosition == p.gridPosition), GameManager.instance.map.Find (i => i.gridPosition == opponent.gridPosition)/*, GameManager.instance.UserPlayers.Where(x => x.gridPosition != p.gridPosition && x.gridPosition != opponent.gridPosition).Select(x => x.gridPosition).ToArray()*/);
			//TODO GameManager.instance.moveCurrentPlayer(path[(int)Mathf.Min(Mathf.Max (path.Count - 1 - 1, 0), movementPerActionPoint - 1)]);

			if (path.Count != null&&path.Count<26) {
				int indexer = 0;
				if (p.ActionPoints - 1 > 3) {
					indexer = (int)Mathf.Min (Mathf.Max (path.Count - 1 - 1, 0), 3);
				} else {
					indexer = (int)Mathf.Min (Mathf.Max (path.Count - 1 - 1, 0), p.ActionPoints - 1);
				}

				while (path[indexer].occupied) {
					indexer--;
					if (indexer <= 0) {
						indexer = 0;
						break;
					}
				}

				AIBehave.instance.AIMove (path [indexer], p);
				//Debug.Log ("ran");
					
				if (p.ActionPoints > p.Weapon.APCost) {
						//			if(opponent.HP>0)
						//		{AIBehave.instance.AIAttack (opponent, p);}
						//		else
					EnemyMove (p);
				}

			

				//p.transform.DOMove(path[(int)Mathf.Min(Mathf.Max (path.Count - 1 - 1, 0), p.ActionPoints - 1)].transform.position,1);

			}

		}
		//}

		p.ActionPoints = (int)p.MaxAP;

	}
	
	}






