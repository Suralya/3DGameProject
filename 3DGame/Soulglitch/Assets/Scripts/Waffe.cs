using UnityEngine;
using System.Collections;

public class Waffe {

	public int Attackrange=5;

	public float Damage=5f;
	public float Hitchance=0.8f;

	public int APCost=8;

	// Use this for initialization
	void Start () {
	
	}

	public Waffe(string name){
		switch (name){
		case "None":{
			Attackrange=1;
			Damage=1f;
			Hitchance=0.5f;
			APCost=5;
			break;}
		case "Rifle":{
			Attackrange=6;
			Damage=5f;
			Hitchance=0.65f;
			APCost=5;
			break;}
		case "Gun":{
			Attackrange=4;
			Damage=6f;
			Hitchance=0.65f;
			APCost=5;
			break;}
		case "Knife":{
			Attackrange=1;
			Damage=30f;
			Hitchance=0.9f;
			APCost=5;
			break;}
		}
	}
	
	// Update is called once per frame
	void Update () {
	//Update der Variablen nach Enum für ausgerüstete Waffen
	}
}
