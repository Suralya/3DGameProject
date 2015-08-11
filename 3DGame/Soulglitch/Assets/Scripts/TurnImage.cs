using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnImage : MonoBehaviour {

	public static TurnImage instance;

	
	void Awake() {
		instance=this;
	}


	public Image Img;
	public Sprite Player,Enemy;


	// Use this for initialization
	void Start () {
		//Img = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TurnOn(){
		if (Img.sprite == Player) {
			Img.sprite=Enemy;
		} else {
			Img.sprite=Player;
		}

	}


}
