using UnityEngine;
using System.Collections;
using DG.Tweening;

public class AIBehave : MonoBehaviour {
	public static AIBehave instance;
	private LineRenderer _lr;
	
	void Awake() {
		instance=this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	/// <summary>
	/// Calls AI Attacking mechanism
	/// </summary>
	/// <param name="target">Target.</param>
	/// <param name="ai">Ai.</param>
	public void AIAttack(Player target,Player ai) {
		_lr = GameManager.instance._lr;

					ai.ActionPoints -= ai.Weapon.APCost;
					
					bool hit = Random.Range (0.0f, 1.0f) <= ai.Weapon.Hitchance;
					
					Vector3 targetpos=target.transform.position;
					targetpos-=ai.transform.position;
					RaycastHit hittarget;
					
					Physics.Raycast(ai.transform.position,targetpos,out hittarget);


                    if (hittarget.collider.gameObject.GetComponent<Player>() != null && hit && hittarget.collider.gameObject.GetComponent<Player>().Equals(target))
                    {
					StartCoroutine(DrawShootTrail(ai, target.transform.position));
						//damage logic
						int amountOfDamage = (int)Mathf.Floor (ai.Weapon.Damage);
						
						target.HP -= amountOfDamage;
						hittarget.collider.gameObject.transform.DOShakeRotation(0.5f,45f,50,90);
						
						Debug.Log (ai.playerName + " successfuly hit " + target.playerName + " for " + amountOfDamage + " damage!");
					} else {
			if(hittarget.collider.gameObject.GetComponent<Player> () != null){
				var targetmissed=target.transform.position;
				targetmissed.y+=1.5f;
				StartCoroutine(DrawShootTrail(ai, targetmissed));
			}else{
				StartCoroutine(DrawShootTrail(ai, hittarget.collider.gameObject.transform.position));
			}


						Debug.Log (ai.playerName + " missed " + target.playerName + "!");
					}

		}

	/// <summary>
	/// Calls AIs Movement
	/// </summary>
	/// <param name="destTile">Destination tile.</param>
	/// <param name="ai">Ai.</param>
	public void AIMove(Tile destTile,Player ai){

	
		
		if (/*destTile.transform.GetComponent<Renderer> ().material.color == Color.magenta && */!destTile.impassible && !destTile.occupied) {
			//removeTileHighlights ();
			if(ai.ActionPoints-1>0)
			{
				ai.ActionPoints--;

				if(TilePathFinder.FindPath (GameManager.instance.map.Find (t => t.gridPosition == ai.gridPosition), destTile)!=null)
				{
			ai.ActionPoints -= TilePathFinder.FindPath (GameManager.instance.map.Find (t => t.gridPosition == ai.gridPosition), destTile).Count;
		
			foreach (Tile t in TilePathFinder.FindPath(GameManager.instance.map.Find(t => t.gridPosition==ai.gridPosition),destTile)) {
				ai.positionQueue.Add (GameManager.instance.map.Find (delegate(Tile obj) {
					return obj.gridPosition == t.gridPosition;
				}).transform.position + Vector3.up);
			//	Debug.Log ("(" + ai.positionQueue [ai.positionQueue.Count - 1].x + "," + ai.positionQueue [ai.positionQueue.Count - 1].y + ")");
			}			
			ai.gridPosition = destTile.gridPosition;
			}
			}
		} else {
		//	Debug.Log ("destination invalid");
		}

	}
	/// <summary>
	/// AI Aiming
	/// </summary>
	/// <returns><c>true</c>, if aim was AIed, <c>false</c> otherwise.</returns>
	/// <param name="target">Target.</param>
	/// <param name="ai">Ai.</param>
	public bool AIAim(Player target,Player ai){

		ai.ActionPoints --;
		
		Vector3 targetpos=target.transform.position;
		targetpos-=ai.transform.position;
		RaycastHit hittarget;
		
		Physics.Raycast(ai.transform.position,targetpos,out hittarget);
		
		
		if (hittarget.collider.gameObject.GetComponent<Player> () != null && hittarget.collider.gameObject.GetComponent<Player> ().Equals (target)) {
			return true;
		} else {
			return false;
		}

	}


/// <summary>
/// Draws the shoot trail for the attack.
/// </summary>
/// <returns>The shoot trail.</returns>
/// <param name="origin">Origin.</param>
/// <param name="target">Target.</param>
	private IEnumerator DrawShootTrail(Player origin,Vector3 target)
	{
		_lr.enabled = false;
		_lr.SetPosition(0, origin.transform.position);
		_lr.SetPosition(1, target);
		
		_lr.enabled = true;
		yield return new WaitForSeconds(0.1f);
		_lr.enabled = false;
	}

	}




//http://docs.unity3d.com/ScriptReference/StateMachineBehaviour.html

