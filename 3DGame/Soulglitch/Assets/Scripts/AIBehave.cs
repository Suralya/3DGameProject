using UnityEngine;
using System.Collections;
using DG.Tweening;

public class AIBehave : MonoBehaviour {
	public static AIBehave instance;
	
	void Awake() {
		instance=this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void AIAttack(Player target,Player ai) {

					ai.ActionPoints -= ai.Weapon.APCost;
					
					bool hit = Random.Range (0.0f, 1.0f) <= ai.Weapon.Hitchance;
					
					Vector3 targetpos=target.transform.position;
					targetpos-=ai.transform.position;
					RaycastHit hittarget;
					
					Physics.Raycast(ai.transform.position,targetpos,out hittarget);
					
					
					if (hit&&hittarget.collider.gameObject.GetComponent<Player>().Equals(target)) {
						
						//damage logic
						int amountOfDamage = (int)Mathf.Floor (ai.Weapon.Damage);
						
						target.HP -= amountOfDamage;
						hittarget.collider.gameObject.transform.DOShakeRotation(0.5f,45f,50,90);
						
						Debug.Log (ai.playerName + " successfuly hit " + target.playerName + " for " + amountOfDamage + " damage!");
					} else {
						Debug.Log (ai.playerName + " missed " + target.playerName + "!");
					}

		}


	public void AIMove(Tile destTile,Player ai){

	
		
		if (/*destTile.transform.GetComponent<Renderer> ().material.color == Color.magenta && */!destTile.impassible && !destTile.occupied) {
			//removeTileHighlights ();
		
			ai.ActionPoints -= TilePathFinder.FindPath (GameManager.instance.map.Find (t => t.gridPosition == ai.gridPosition), destTile).Count;
		
			foreach (Tile t in TilePathFinder.FindPath(GameManager.instance.map.Find(t => t.gridPosition==ai.gridPosition),destTile)) {
				ai.positionQueue.Add (GameManager.instance.map.Find (delegate(Tile obj) {
					return obj.gridPosition == t.gridPosition;
				}).transform.position + Vector3.up);
				Debug.Log ("(" + ai.positionQueue [ai.positionQueue.Count - 1].x + "," + ai.positionQueue [ai.positionQueue.Count - 1].y + ")");
			}			
			ai.gridPosition = destTile.gridPosition;
		
		} else {
			Debug.Log ("destination invalid");
		}

	}



	}




//http://docs.unity3d.com/ScriptReference/StateMachineBehaviour.html

