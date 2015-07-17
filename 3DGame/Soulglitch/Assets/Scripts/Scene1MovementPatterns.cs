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

	public override void CivilianMove(AIPlayer p){
		bool TurnOn=true;
		while (!GameManager.instance._userturn&&TurnOn) {

			Debug.Log ("Civilian  movement");
			TurnOn=false;
		}

		p.ActionPoints = (int)p.MaxAP;

	}

	public override void EnemyMove(AIPlayer p){
		bool TurnOn=true;
		//while (!GameManager.instance._userturn&&TurnOn) {


		Debug.Log ("Enemy  movement");

			List<Tile> attacktilesInRange = TileHighlight.FindAtackHighlight(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition), p.Weapon.Attackrange);
			List<Tile> movementToAttackTilesInRange = TileHighlight.FindHighlight(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition),p.ActionPoints- p.Weapon.APCost+  p.Weapon.Attackrange);
			List<Tile> movementTilesInRange = TileHighlight.FindAIMoveHighlight(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition), p.ActionPoints+1000);

			if (attacktilesInRange.Where (x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y.gridPosition == x.gridPosition).Count () > 0).Count () > 0) {
			//if(attacktilesInRange.Count>0)
			Debug.Log ("Someone is in Range");
			var opponentsInRange = attacktilesInRange.Select (x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y.gridPosition == x.gridPosition).First () : null).ToList ();
			Player opponent = opponentsInRange.OrderBy (x => x != null ? -x.HP : 1000).First ();

			Debug.Log ("The Player in Range is" + opponent.name);

			while(p.ActionPoints>p.Weapon.APCost&&opponent.HP>0)
			AIBehave.instance.AIAttack (opponent, p);


		} else if (movementTilesInRange.Where (x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0).Count () > 0) {



			var opponentsInRange = movementTilesInRange.Select(x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.UserPlayers.Where(y => y.HP > 0 && y.gridPosition == x.gridPosition).First() : null).ToList();
			Player opponent = opponentsInRange.OrderBy (x => x != null ? -x.HP : 1000).ThenBy (x => x != null ? TilePathFinder.FindPath(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition),GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition)).Count() : 1000).First ();
			
		//	GameManager.instance.removeTileHighlights();
		//	GameManager.instance.highlightTilesAt(p.gridPosition, Color.blue, p.ActionPoints);
			Debug.Log(p.playerName+" will zu "+opponent.name);
			List<Tile> path = TilePathFinder.FindAIPath (GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition),GameManager.instance.map.Find(i=>i.gridPosition==opponent.gridPosition)/*, GameManager.instance.UserPlayers.Where(x => x.gridPosition != p.gridPosition && x.gridPosition != opponent.gridPosition).Select(x => x.gridPosition).ToArray()*/);
			//TODO GameManager.instance.moveCurrentPlayer(path[(int)Mathf.Min(Mathf.Max (path.Count - 1 - 1, 0), movementPerActionPoint - 1)]);

			if(path.Count!=null)
			{
			int indexer=(int)Mathf.Min(Mathf.Max (path.Count - 1 - 1, 0), p.ActionPoints - 1);

			while(path[indexer].occupied)
			{indexer--;
					if(indexer<=0){indexer=0;break;}
			}

			AIBehave.instance.AIMove(path[indexer],p);
			Debug.Log("ran");

			if(p.ActionPoints>p.Weapon.APCost&&opponent.HP>0)
				AIBehave.instance.AIAttack (opponent, p);
			}
			else{Debug.Log("Can't move");}

			//p.transform.DOMove(path[(int)Mathf.Min(Mathf.Max (path.Count - 1 - 1, 0), p.ActionPoints - 1)].transform.position,1);

		}


			TurnOn=false;
		//}

		p.ActionPoints = (int)p.MaxAP;

	}
	
}






/*	//priority queue
		List<Tile> attacktilesInRange = TileHighlight.FindHighlight(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition), p.Weapon.Attackrange);
		List<Tile> movementToAttackTilesInRange = TileHighlight.FindHighlight(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition),p.ActionPoints- p.Weapon.APCost+  p.Weapon.Attackrange);
		List<Tile> movementTilesInRange = TileHighlight.FindHighlight(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition), p.ActionPoints + 1000);

		//attack if in range and with lowest HP
		if (attacktilesInRange.Where(x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count() > 0).Count () > 0) {
			var opponentsInRange = attacktilesInRange.Select(x => GameManager.instance.UserPlayers.Where (y =>& y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.UserPlayers.Where(y => y.gridPosition == x.gridPosition).First() : null).ToList();
			Player opponent = opponentsInRange.OrderBy (x => x != null ? -x.HP : 1000).First ();
			
			GameManager.instance.removeTileHighlights();
			p.moving = false;
			p.attacking = true;
			GameManager.instance.highlightTilesAt(p.gridPosition, Color.red, p.Weapon.Attackrange);
			
			//TODO GameManager.instance.attackWithCurrentPlayer(GameManager.instance.map[(int)opponent.gridPosition.x][(int)opponent.gridPosition.y]);
			Debug.Log("EnemyAttack");
		}

		//move toward nearest attack range of opponent
		else if (!p.moving && movementToAttackTilesInRange.Where(x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count() > 0).Count () > 0) {
			var opponentsInRange = movementToAttackTilesInRange.Select(x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.UserPlayers.Where(y => y.gridPosition == x.gridPosition).First() : null).ToList();
			Player opponent = opponentsInRange.OrderBy (x => x != null ? -x.HP : 1000).ThenBy (x => x != null ? TilePathFinder.FindPath(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition),GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition)).Count() : 1000).First ();
			
			GameManager.instance.removeTileHighlights();
			p.moving = true;
			p.attacking = false;
			GameManager.instance.highlightTilesAt(p.gridPosition, Color.blue, p.ActionPoints- p.Weapon.APCost, false);
			
			List<Tile> path = TilePathFinder.FindPath (GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition),GameManager.instance.map.Find(i=>i.gridPosition==opponent.gridPosition), GameManager.instance.UserPlayers.Where(x => x.gridPosition != p.gridPosition && x.gridPosition != opponent.gridPosition).Select(x => x.gridPosition).ToArray());

			//TODO GameManager.instance.moveCurrentPlayer(path[(int)Mathf.Max(0, path.Count - 1 - attackRange)]);
			Debug.Log("EnemyMove");
		}

		//move toward nearest opponent
		else if (!p.moving && movementTilesInRange.Where(x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count() > 0).Count () > 0) {
			var opponentsInRange = movementTilesInRange.Select(x => GameManager.instance.UserPlayers.Where (y => y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.UserPlayers.Where(y => y.gridPosition == x.gridPosition).First() : null).ToList();
			Player opponent = opponentsInRange.OrderBy (x => x != null ? -x.HP : 1000).ThenBy (x => x != null ? TilePathFinder.FindPath(GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition),GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition)).Count() : 1000).First ();
			
			GameManager.instance.removeTileHighlights();
			p.moving = true;
			p.attacking = false;
			GameManager.instance.highlightTilesAt(p.gridPosition, Color.blue, p.ActionPoints, false);
			
			List<Tile> path = TilePathFinder.FindPath (GameManager.instance.map.Find(i=>i.gridPosition==p.gridPosition),GameManager.instance.map.Find(i=>i.gridPosition==opponent.gridPosition), GameManager.instance.UserPlayers.Where(x => x.gridPosition != p.gridPosition && x.gridPosition != opponent.gridPosition).Select(x => x.gridPosition).ToArray());
			//TODO GameManager.instance.moveCurrentPlayer(path[(int)Mathf.Min(Mathf.Max (path.Count - 1 - 1, 0), movementPerActionPoint - 1)]);
			Debug.Log("EnemyMove");
		}*/


