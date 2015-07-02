using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraCenteronCurrent : MonoBehaviour {
	public static CameraCenteronCurrent instance;

	public float timescale=1;

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CamonCurent(){
		this.transform.DOMove (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].transform.position,timescale);
	}
}
