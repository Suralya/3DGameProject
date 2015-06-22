using UnityEngine;
using System.Collections;

public class Camermovement : MonoBehaviour {
	public static Camermovement instance;
	
	public bool Rotating=false;
	public int RotationSpeed=70;
	public Vector3 FormerCharPosition;
	int i;
	public float faktor=1.3f; 
	// Use this for initialization

	public Vector3 TargetPosition;
	public Vector3 temp;

	void Awake() {
		instance = this;
	}
	
	void Start () {

		FormerCharPosition = GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform.position;
		Vector3 temp = FormerCharPosition + new Vector3 (5.96f, 0f, -15.05f);
		temp.y = 7.32f;
		transform.position = temp;
		TargetPosition = transform.position;
		this.transform.SetParent(GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, TargetPosition, Time.deltaTime * faktor);

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
		temp = transform.position;
		Rotating = false;

		temp -= FormerCharPosition;


		temp.x += GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform.position.x;
		temp.y = 7.32f;
		temp.z += GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform.position.z;
		//transform.position = temp;

		//Richtig beechnen!!!
		TargetPosition = temp;
		Debug.Log (temp);
		//transform.position = Vector3.Lerp(transform.position,temp,Time.deltaTime*faktor);


		this.transform.SetParent(GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform);
		//transform.rotation = new Quaternion (-0.1436848f, 0.1962f, -0.005494709f,-0.969964f);
		FormerCharPosition = GameManager.instance.UserPlayers [GameManager.instance.currentPlayerIndex].transform.position;

	}

	public void RotateCam(int j){
		if(Rotating)
		transform.RotateAround (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].transform.position,new Vector3(0.0f,1.0f,0.0f),RotationSpeed*j * Time.deltaTime);
	}
}
