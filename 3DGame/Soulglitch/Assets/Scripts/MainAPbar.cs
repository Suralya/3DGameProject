using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainAPbar : MonoBehaviour {

	public Image APBar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		APBar.fillAmount = (GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].ActionPoints / GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].MaxAP);
	}
}
