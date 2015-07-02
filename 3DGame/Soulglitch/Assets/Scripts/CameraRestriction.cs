using UnityEngine;
using System.Collections;

public class CameraRestriction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 temp = this.transform.position;

			if(temp.z < 0)
		{
			temp.z = 0;
		}
		if(temp.z > GameManager.instance.mapSizeY)
		{
			temp.z = GameManager.instance.mapSizeY;
		}
		
		if(temp.x < 0)
		{
			temp.x = 0;
		}
		if(temp.x > GameManager.instance.mapSizeX)
		{
			temp.x = GameManager.instance.mapSizeX;
		}

		this.transform.position = temp;
	}



}
