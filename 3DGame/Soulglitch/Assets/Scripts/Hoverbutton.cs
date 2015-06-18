using UnityEngine;
using System.Collections;

public class Hoverbutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHoverAttack(){
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_attack_de.txt")+GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.APCost;
	}

	public void ExitHoverAttack(){
		GameManager.instance.Tooltiptext.text=" ";
	}

	public void OnHoverMove(){
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_move_de.txt");
	}

	public void ExitHoverMove(){
		GameManager.instance.Tooltiptext.text=" ";
	}

	public void OnHoverAim(){
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_aim_de.txt");
	}

	public void ExitHoverAim(){
		GameManager.instance.Tooltiptext.text=" ";
	}

	public void OnHoverWeaponChange(){
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_weaponchange_de.txt");
	}
	
	public void ExitHoverWeaponChange(){
		GameManager.instance.Tooltiptext.text=" ";
	}
	public void OnHoverNextTurn(){
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_nextturn_de.txt");
	}

	public void ExitHoverNextTurn(){
		GameManager.instance.Tooltiptext.text=" ";
	}
}
