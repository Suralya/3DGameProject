using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Comments : MonoBehaviour {
	public static Comments instance;
	
	public Canvas CommentsCanvas;
	public Image Avatar;
	public Sprite Leader;
	public Text CommentsText;
	public Text CommentName;

	public int Secondsshown=15;
	public int Counter;
	public bool Routine=false;
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

	public void MakeComment(string name, Sprite avatar, string txt){
		CommentsCanvas.enabled = true;
		Avatar.overrideSprite = avatar;
		CommentName.text = name;
		CommentsText.text=txt;

		StartCoroutine (WaitTillHide ());
	}

	public void MakeComment(string name, Sprite avatar, string action, int id){
		int ID=id;

		while (System.IO.File.ReadAllText("Assets/Texts/Comments/Comment_"+action+"_"+name+"_"+ID+".txt")!=null) {
			ID++;
			
			try
			{
				string test=System.IO.File.ReadAllText("Assets/Texts/Comments/Comment_"+action+"_"+name+"_"+ID+".txt");
			}
			catch { break;}
			
		}
		//ID-=1;
		//Debug.Log (ID);
		
		int temp= Random.Range(1,ID);
		//Debug.Log (temp);

		CommentsCanvas.enabled = true;
		Avatar.overrideSprite = avatar;
		CommentName.text = name;
		CommentsText.text=System.IO.File.ReadAllText("Assets/Texts/Comments/Comment_"+action+"_"+name+"_"+temp+".txt");
		
		StartCoroutine (WaitTillHide ());
	}

	public void MakeComment(string name, Sprite avatar, string action,string condition, int id){
		int ID =id;

		while (System.IO.File.ReadAllText("Assets/Texts/Comments/Comment_"+action+"_"+condition+"_"+name+"_"+ID+".txt")!=null) {
			ID++;

			try
			{
				string test=System.IO.File.ReadAllText("Assets/Texts/Comments/Comment_"+action+"_"+condition+"_"+name+"_"+ID+".txt");
			}
			catch { break;}

		}
		//ID-=1;
		//Debug.Log (ID);

		int temp= Random.Range(1,ID);
		//Debug.Log (temp);
		CommentsCanvas.enabled = true;
		Avatar.overrideSprite = avatar;
		CommentName.text = name;
		CommentsText.text=System.IO.File.ReadAllText("Assets/Texts/Comments/Comment_"+action+"_"+condition+"_"+name+"_"+temp+".txt");
		
		StartCoroutine (WaitTillHide ());
	}



	public void MakeComment(string txt){
		CommentsCanvas.enabled = true;
		Avatar.overrideSprite = Leader;

		CommentsText.text=txt;
		CommentName.text="Commander";

		StartCoroutine (WaitTillHide ());
	}

	public IEnumerator WaitTillHide(){

		Counter=Secondsshown;
		if (!Routine) {
			Routine = true;
			while (Counter>0) {
				yield return new WaitForSeconds (1);
				Counter--;
			}
			Routine = false;
			HideComment ();
		}

	}

	public void HideComment(){
		CommentsCanvas.enabled = false;
		CommentsText.text = "";
		CommentName.text="";
	}

}
