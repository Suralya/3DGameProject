using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Comments : MonoBehaviour {
	public static Comments instance;
	
	public Canvas CommentsCanvas;
	public Image Avatar;
	public Sprite Leader;
	public Text CommentsText;

	public int Secondsshown=15;
	// Use this for initialization

	void Awake() {
		instance = this;
	}
	
	void Start () {
		CommentsCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MakeComment(Sprite avatar, string txtID){
		CommentsCanvas.enabled = true;
		Avatar.overrideSprite = avatar;

		CommentsText.text=System.IO.File.ReadAllText(txtID);

		StartCoroutine (WaitTillHide ());
	}

	public void MakeComment(string txtID){
		CommentsCanvas.enabled = true;
		Avatar.overrideSprite = Leader;

		CommentsText.text=System.IO.File.ReadAllText(txtID);

		StartCoroutine (WaitTillHide ());
	}

	public IEnumerator WaitTillHide(){
		yield return new WaitForSeconds(Secondsshown);
		CommentsCanvas.enabled = false;
		CommentsText.text = "";
	}
}
