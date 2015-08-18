using UnityEngine;
using System.Collections;

public class Waffe {

	public int Attackrange=5;
    public string Weaponname;
	public float Damage=5f;
	public float Hitchance=0.8f;
    public bool healing = false;
	public int APCost=8;

	// Use this for initialization
	void Start () {
	
	}
/// <summary>
/// Sets Weapon
/// </summary>
/// <param name="name">Name.</param>
	public Waffe(string name){
		switch (name){
		case "None":{
			Weaponname="Unbewaffnet";
			Attackrange=1;
			Damage=1f;
			Hitchance=0.65f;
			APCost=5;
            healing = false;
			break;}
		case "Rifle":{
			Weaponname="Sturmgewehr";
			Attackrange=24;
			Damage=6f;
			Hitchance=0.75f;
			APCost=5;
            healing = false;
			break;}
		case "Gun":{
			Weaponname="Pistole";
			Attackrange=12;
			Damage=7f;
			Hitchance=0.65f;
			APCost=5;
            healing = false;
			break;}
		case "Knife":{
			Weaponname="Messer";
			Attackrange=1;
			Damage=3f;
			Hitchance=0.5f;
			APCost=4;
            healing = false;
			break;}
		case "Medicgun":{
			Weaponname=name;
			Attackrange=5;
			Damage=4f;
			Hitchance=0.99f;
			APCost=6;
			healing = true;
			break;}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
