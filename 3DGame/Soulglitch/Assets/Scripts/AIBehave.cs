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

			

				
				
				
				//Debug.Log ("p.x: " + players[currentPlayerIndex].gridPosition.x + ", p.y: " + players[currentPlayerIndex].gridPosition.y + " t.x: " + target.gridPosition.x + ", t.y: " + target.gridPosition.y);
		/*		if (ai.gridPosition.x >= target.gridPosition.x - ai.Weapon.Attackrange && ai.gridPosition.x <= target.gridPosition.x + ai.Weapon.Attackrange &&
				    ai.gridPosition.y >= target.gridPosition.y - ai.Weapon.Attackrange && ai.gridPosition.y <= target.gridPosition.y + ai.Weapon.Attackrange) {
*/
					ai.ActionPoints -= ai.Weapon.APCost;
					
					//removeTileHighlights ();
					
					//attack logic
					//roll to hit
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

			/*	} else {
					Debug.Log ("Target is not adjacent!");
				}
				*/
		}
		
	}




//http://docs.unity3d.com/ScriptReference/StateMachineBehaviour.html

