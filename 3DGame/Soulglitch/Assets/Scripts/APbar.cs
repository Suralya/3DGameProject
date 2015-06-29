using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class APbar : MonoBehaviour {

	public Image APbarCharOne;
	public Image APbarCharTwo;
	public Image APbarCharThree;
	public Image APbarCharFour;

	
	public float Testing;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Testing=(GameManager.instance.UserPlayers [0].HP / GameManager.instance.UserPlayers [0].MaxHP);
		
		APbarCharOne.fillAmount = (GameManager.instance.UserPlayers [0].ActionPoints / GameManager.instance.UserPlayers [0].MaxAP);
		APbarCharTwo.fillAmount = (GameManager.instance.UserPlayers [1].ActionPoints / GameManager.instance.UserPlayers [1].MaxAP);
		APbarCharThree.fillAmount = (GameManager.instance.UserPlayers [2].ActionPoints / GameManager.instance.UserPlayers [2].MaxAP);
		APbarCharFour.fillAmount = (GameManager.instance.UserPlayers [3].ActionPoints / GameManager.instance.UserPlayers [3].MaxAP) ;
		
	}
}
