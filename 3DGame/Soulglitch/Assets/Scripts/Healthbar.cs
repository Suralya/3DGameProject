using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

	public Image HealthbarCharOne;
	public Image HealthbarCharTwo;
	public Image HealthbarCharThree;
	public Image HealthbarCharFour;

	public float Testing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Testing=(GameManager.instance.UserPlayers [0].HP / GameManager.instance.UserPlayers [0].MaxHP);

		HealthbarCharOne.fillAmount = (GameManager.instance.UserPlayers [0].HP / GameManager.instance.UserPlayers [0].MaxHP);
		HealthbarCharTwo.fillAmount = (GameManager.instance.UserPlayers [1].HP / GameManager.instance.UserPlayers [1].MaxHP);
		HealthbarCharThree.fillAmount = (GameManager.instance.UserPlayers [2].HP / GameManager.instance.UserPlayers [2].MaxHP);
		HealthbarCharFour.fillAmount = (GameManager.instance.UserPlayers [3].HP / GameManager.instance.UserPlayers [3].MaxHP) ;
	
	}
}
