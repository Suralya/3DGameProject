using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialoughesSzene1 : MonoBehaviour {

	public static DialoughesSzene1 instance;
	public bool commenting=false;

	public Canvas DialogueCanvas;

	public Image CharRight,CharLeft;
	public Text CharName,DialugeText;

	public Sprite Deera, Davis, Phil, Platina, Commander,Null,SpriteToSet;

	public bool Skip=false;


	void Awake() {
		instance = this;
	}

	void Start(){
		//DialogueCanvas.enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Skip=true;
		}
	}

	public IEnumerator ShowDialogue(int missionnumber,int setnumber){

		CharLeft.sprite = Null;
		CharRight.sprite = Null;

		DialogueCanvas.enabled = true;


		GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking=false;
		GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming=false;
		GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving=false;
		GameManager.instance.removeTileHighlights ();
		Time.timeScale=0;
		Hotkey.hotk.enabled = false;


		int partlength = 1;
		while (System.IO.File.ReadAllText("Assets/Texts/Dialogues/Missiontext_Mission_"+missionnumber+"_Dialogue_"+setnumber+"_Part_"+partlength+".txt")!=null) {
			partlength++;
			
			try
			{
				string test=System.IO.File.ReadAllText("Assets/Texts/Dialogues/Missiontext_Mission_"+missionnumber+"_Dialogue_"+setnumber+"_Part_"+partlength+".txt");
			}
			catch { break;}
			
		}

		int partindex = 1;
		while(partindex<partlength){

			string temp=System.IO.File.ReadAllText("Assets/Texts/Dialogues/Missiontext_Mission_"+missionnumber+"_Dialogue_"+setnumber+"_Part_"+partindex+".txt");
			var Text = temp.Split("\n"[0]);

		//	temp=Text[0];

			Debug.Log(Text[0]);
			//SpriteToSet=Davis;

			int Identifier= System.Convert.ToInt32(Text[0]);

			switch(Identifier)
			{
			case 1:{
				SpriteToSet=Davis;
					break;
				}
			case 3:{
				SpriteToSet=Deera;
				break;
			}
			case 2:{
				SpriteToSet=Platina;
				break;
			}
			case 4:{
				SpriteToSet=Phil;
				break;
			}
			case 0:{
				SpriteToSet=Commander;
				break;
			}
			}



			 if(partindex%2==0)
			{
				CharLeft.sprite=SpriteToSet;
			}else{
				CharRight.sprite=SpriteToSet;
			}

			CharName.text=Text[1];

			DialugeText.text="";
			int counter=0;
			while (counter<Text[2].Length-1&&!Skip)
			{
				yield return new WaitForSeconds (0.01f);
				DialugeText.text=DialugeText.text+Text[2][counter];
				counter++;

			}
			DialugeText.text=Text[2];
			Skip=false;
			partindex++;



			int i=1;

			while (i<40&&!Skip)
			{
				yield return new WaitForSeconds (0.02f);
				i++;
			}
			Skip=false;


		}

		DialogueCanvas.enabled = false;
		Time.timeScale=1;
		Hotkey.hotk.enabled = true;

		if (setnumber==3)
			Win_Lose_Screen.instance.MissionWon ();
	}
	

	public void TurnOne(){
		StartCoroutine (ShowDialogue(1,1));
	}

	public void CivilKill(){
		StartCoroutine (ShowDialogue(1,2));
	}

	public void MissionWin(){
		if (!commenting) {
			commenting = true;
			StartCoroutine (ShowDialogue (1, 3));
		}
	}

}
