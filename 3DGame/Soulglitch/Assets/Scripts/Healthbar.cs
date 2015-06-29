using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

	public Image HealthCharOne;
	public Image HealthCharTwo;
	public Image HealthCharThree;
	public Image HealthCharFour;

	public float Testing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Testing=(GameManager.instance.UserPlayers [0].HP / GameManager.instance.UserPlayers [0].MaxHP);

		HealthCharOne.fillAmount = (GameManager.instance.UserPlayers [0].HP / GameManager.instance.UserPlayers [0].MaxHP);
		HealthCharTwo.fillAmount = (GameManager.instance.UserPlayers [1].HP / GameManager.instance.UserPlayers [1].MaxHP);
		HealthCharThree.fillAmount = (GameManager.instance.UserPlayers [2].HP / GameManager.instance.UserPlayers [2].MaxHP);
		HealthCharFour.fillAmount = (GameManager.instance.UserPlayers [3].HP / GameManager.instance.UserPlayers [3].MaxHP) ;
	
	}
}
