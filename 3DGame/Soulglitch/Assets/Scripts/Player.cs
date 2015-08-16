using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Player : MonoBehaviour {

	public bool CurrentWeaponisOne = true;
	public Waffe Weapon=new Waffe("Knife");
	public enum Weapons
	{
		None,
		Rifle,
		Gun,
		Knife,
		Medicgun
	};

	public Weapons WeaponOne=Weapons.None;
	public Weapons WeaponTwo=Weapons.None;
	public Waffe[] OwnedWeapons= new Waffe[2];


	public Vector2 gridPosition = Vector2.zero;

	public bool selected = false;
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;

	public bool moving=false;
	public bool attacking =false;
	public bool aiming=false;

	public Sprite Avatar;

	public string playerName = "Robin";
	public float HP = 10f;
	public float MaxHP=10f;
	public int ActionPoints = 12;
	public float MaxAP=12;


	public List<Vector3> positionQueue = new List<Vector3>();	
	
	void Awake () {
		moveDestination = transform.position;
	}

	// Use this for initialization
	public void Ini () {
		SetWeapons ();
		Weapon = OwnedWeapons[0];
		Debug.Log ("waffe ausgewählt");

	}


	// Update is called once per frame
	void Update () {

	
	}

	public virtual void TurnUpdate () {
		if (ActionPoints <= 0) {
			moving = false;
			attacking = false;
			
	}
}
	/// <summary>
	/// Manages events on mouse on down.
	/// </summary>
	void OnMouseDown(){

		if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking) {
			GameManager.instance.attackWithCurrentPlayer(GameManager.instance.map.Find(t=> t.gridPosition==this.gridPosition));
			Debug.Log ("Angriff auf"+this.transform.position.x+","+this.transform.position.z);
		}
		else if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming) {
			GameManager.instance.aimWithCurrentPlayer(GameManager.instance.map.Find(t=> t.gridPosition==this.gridPosition));
			Debug.Log ("Aiming"+this.transform.position.x+","+this.transform.position.z);
		}else if(!GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
		   &&!GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
		   &&!GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
		   &&GameManager.instance.UserPlayers[GameManager.instance.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition)].HP>0
		   &&GameManager.instance.UserPlayers.Any(t=>t.gridPosition==this.gridPosition)){
			GameManager.instance.formerPlayerIndex=GameManager.instance.currentPlayerIndex;
			GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].selected=false;
			GameManager.instance.currentPlayerIndex=GameManager.instance.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition);
			GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].selected=true;
			CameraCenteronCurrent.instance.CamonCurent();
			
		}
	}

	public virtual void AIMove(){}
	/// <summary>
	/// Sets the weapons.
	/// </summary>
	public void SetWeapons(){

		switch (WeaponOne) {
		case Weapons.None:
		{OwnedWeapons[0]=new Waffe("None");
				break;}
		case Weapons.Rifle:
		{OwnedWeapons[0]=new Waffe("Rifle");
			break;}
		case Weapons.Gun:
		{OwnedWeapons[0]=new Waffe("Gun");
			break;}
		case Weapons.Knife:
		{OwnedWeapons[0]=new Waffe("Knife");
			break;}
		case Weapons.Medicgun:
		{OwnedWeapons[0]=new Waffe("Medicgun");
			break;}
		}

		switch (WeaponTwo) {
		case Weapons.None:
		{OwnedWeapons[1]=new Waffe("None");
			break;}
		case Weapons.Rifle:
		{OwnedWeapons[1]=new Waffe("Rifle");
			break;}
		case Weapons.Gun:
		{OwnedWeapons[1]=new Waffe("Gun");
			break;}
		case Weapons.Knife:
		{OwnedWeapons[1]=new Waffe("Knife");
			break;}
		case Weapons.Medicgun:
		{OwnedWeapons[1]=new Waffe("Medicgun");
			break;}
		}

	}
}