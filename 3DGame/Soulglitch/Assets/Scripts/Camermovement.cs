using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Camermovement : MonoBehaviour {
	public static Camermovement instance;
	
	public bool Rotating=false;
	public int RotationSpeed=70;
	public Vector3 FormerCharPosition;
	public float timescale=1;
	int i;
	// Use this for initialization

	void Awake() {
		instance = this;
	}
	
	void Start () {

		FormerCharPosition = GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform.position;
		Vector3 temp = FormerCharPosition + new Vector3 (5.96f, 0f, -15.05f);
		temp.y = 7.32f;
		transform.position = temp;
		this.transform.SetParent(GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R) && !Rotating&&!Input.GetKeyDown (KeyCode.Z)) {
			i=1;
			Rotating = true;
		} else if(Input.GetKeyUp (KeyCode.R) && Rotating&&!Input.GetKeyDown (KeyCode.Z)){
			Rotating=false;
		}

		if (Input.GetKeyDown (KeyCode.Z) && !Rotating&&!Input.GetKeyDown (KeyCode.R)) {
			i=-1;
			Rotating = true;
		} else if(Input.GetKeyUp (KeyCode.Z) && Rotating&&!Input.GetKeyDown (KeyCode.R)){
			Rotating=false;
		}
		RotateCam(i);
	}

	public void ChangeCamPosition(){
		if(!GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving){
		Vector3 temp = transform.position;
		Rotating = false;

		temp -= FormerCharPosition;


		temp.x += GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform.position.x;
		temp.y = 7.32f;
		temp.z += GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform.position.z;
		transform.DOMove(temp,timescale);


		this.transform.SetParent(GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform);
		//transform.rotation = new Quaternion (-0.1436848f, 0.1962f, -0.005494709f,-0.969964f);
		FormerCharPosition = GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform.position;
		}
	}

	public void RotateCam(int j){
		if(Rotating)
		transform.RotateAround (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].transform.position,new Vector3(0.0f,1.0f,0.0f),RotationSpeed*j * Time.deltaTime);
	}
}
