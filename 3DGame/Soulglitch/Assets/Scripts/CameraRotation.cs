using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {


	public bool Rotating=false;
	public int RotationSpeed=70;

	int i;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q) && !Rotating&&!Input.GetKeyDown (KeyCode.Z)) {
			i=1;
			Rotating = true;
		} else if(Input.GetKeyUp (KeyCode.Q) && Rotating&&!Input.GetKeyDown (KeyCode.Z)){
			Rotating=false;
		}

		if (Input.GetKeyDown (KeyCode.E) && !Rotating&&!Input.GetKeyDown (KeyCode.R)) {
			i=-1;
			Rotating = true;
		} else if(Input.GetKeyUp (KeyCode.E) && Rotating&&!Input.GetKeyDown (KeyCode.R)){
			Rotating=false;
		}
		RotateCam(i);

}

	public void RotateCam(int j){
		if(Rotating)
			transform.RotateAround (this.transform.position,new Vector3(0.0f,1.0f,0.0f),RotationSpeed*j * Time.deltaTime);
	}
}