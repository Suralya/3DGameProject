using UnityEngine;
using System.Collections;

public class Hoverbutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Raises the hover attack tooltip if tooltip is enabled.
	/// </summary>
	public void OnHoverAttack(){
		if(!GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.healing)
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_attack_de.txt")+GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.APCost+" AP";
		else
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_heal_de.txt")+GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.APCost+" AP";
	}

	/// <summary>
	/// Deletes the hover attack tooltip if tooltip is enabled.
	/// </summary>
	public void ExitHoverAttack(){
		GameManager.instance.Tooltiptext.text=" ";
	}

	/// <summary>
	/// Raises the hover move tooltip if tooltip is enabled.
	/// </summary>
	public void OnHoverMove(){
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_move_de.txt");
	}

	/// <summary>
	/// Deletes the hover move tooltip if tooltip is enabled.
	/// </summary>
	public void ExitHoverMove(){
		GameManager.instance.Tooltiptext.text=" ";
	}

	/// <summary>
	/// Raises the hover aim tooltip if tooltip is enabled.
	/// </summary>
	public void OnHoverAim(){
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_aim_de.txt");
	}

	/// <summary>
	/// Deletes the hover aim tooltip if tooltip is enabled.
	/// </summary>
	public void ExitHoverAim(){
		GameManager.instance.Tooltiptext.text=" ";
	}

	/// <summary>
	/// Raises the hover weapon change tooltip if tooltip is enabled.
	/// </summary>
	public void OnHoverWeaponChange(){
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_weaponchange_de.txt");
	}

	/// <summary>
	/// Deletes the hover weapon change tooltip if tooltip is enabled.
	/// </summary>
	public void ExitHoverWeaponChange(){
		GameManager.instance.Tooltiptext.text=" ";
	}

	/// <summary>
	/// Raises the hover next turn tooltip if tooltip is enabled.
	/// </summary>
	public void OnHoverNextTurn(){
		GameManager.instance.Tooltiptext.text= System.IO.File.ReadAllText("Assets/Texts/Tooltip_nextturn_de.txt");
	}

	/// <summary>
	/// Deletes the hover next turn tooltip if tooltip is enabled.
	/// </summary>
	public void ExitHoverNextTurn(){
		GameManager.instance.Tooltiptext.text=" ";
	}
}
