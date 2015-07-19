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

	public Waffe(string name){
		switch (name){
		case "None":{
			Weaponname=name;
			Attackrange=1;
			Damage=1f;
			Hitchance=0.5f;
			APCost=5;
            healing = false;
			break;}
		case "Rifle":{
			Weaponname=name;
			Attackrange=6;
			Damage=5f;
			Hitchance=0.65f;
			APCost=5;
            healing = false;
			break;}
		case "Gun":{
			Weaponname=name;
			Attackrange=4;
			Damage=6f;
			Hitchance=0.65f;
			APCost=5;
            healing = false;
			break;}
		case "Knife":{
			Weaponname=name;
			Attackrange=1;
			Damage=3f;
			Hitchance=0.5f;
			APCost=4;
            healing = false;
			break;}
		case "Medicgun":{
			Weaponname=name;
			Attackrange=4;
			Damage=6f;
			Hitchance=0.65f;
			APCost=5;
			healing = true;
			break;}
		}
	}
	
	// Update is called once per frame
	void Update () {
	//Update der Variablen nach Enum für ausgerüstete Waffen
	}
}
