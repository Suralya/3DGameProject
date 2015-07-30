using UnityEngine;
using System.Collections;

public class DialoughesSzene1 : MonoBehaviour {

	public static DialoughesSzene1 instance;
	public bool commenting=false;

	void Awake() {
		instance = this;
	}



	public IEnumerator TurnOneText(){
		commenting = true;
		Comments.instance.MakeComment ("BDU E-Sheep bitte kommen! Habt ihr das Ziel erreicht?");
		yield return new WaitForSeconds (3);
		Comments.instance.MakeComment ("Davis",GameManager.instance.UserPlayers.Find(x=>x.playerName=="Davis").Avatar,"Hier Davis Cohen, wir haben soeben die Lagerhalle betreten.");
		yield return new WaitForSeconds (4);
		Comments.instance.MakeComment ("Schaltet jeden dieser Drecksbioroiden aus, bevor auch nur einer von ihnen entkommen kann, wenn sie erst einmal in der Stadt sind wird es schwer sie ausfindig zu machen.");
		yield return new WaitForSeconds (4);
		Comments.instance.MakeComment ("Davis",GameManager.instance.UserPlayers.Find(x=>x.playerName=="Davis").Avatar,"Wissen wir, nur scheint es hier recht belebt zu sein und Kisten voller Waffen sehe ich auch.");
		yield return new WaitForSeconds (4);
		Comments.instance.MakeComment ("Dann ist es ja gut, dass ihr diesmal Phil dabei habt. Ihr werdet ihn dann ja wohl brauchen.");
		yield return new WaitForSeconds (4);
		Comments.instance.MakeComment ("Phil",GameManager.instance.UserPlayers.Find(x=>x.playerName=="Phil").Avatar,"Na ich hoffe, dass ihr nicht wirklich meine Hilfe braucht, es wäre besser wenn wir alle unverletzt blieben.");
		yield return new WaitForSeconds (4);
		Comments.instance.MakeComment ("Platina",GameManager.instance.UserPlayers.Find(x=>x.playerName=="Platina").Avatar,"Keine Sorge, Anfänger wir machen das ja nicht zum ersten mal.");
		yield return new WaitForSeconds (4);
		Comments.instance.MakeComment ("Deera",GameManager.instance.UserPlayers.Find(x=>x.playerName=="Deera").Avatar,"Sei nicht so fies zu ihm!");
		yield return new WaitForSeconds (2);
		Comments.instance.MakeComment ("Davis",GameManager.instance.UserPlayers.Find(x=>x.playerName=="Davis").Avatar,"Ruhe! Alles klar, haltet die Augen offen und langsam vorwärts. Schießt nur, wenn ihr euch sicher seid, dass das Ziel kein Zivilist ist.");
		yield return new WaitForSeconds (3);
		Comments.instance.MakeComment ("Deera",GameManager.instance.UserPlayers.Find(x=>x.playerName=="Deera").Avatar,"Verstanden, Chef!");
		yield return new WaitForSeconds (1);
		Comments.instance.MakeComment ("Platina",GameManager.instance.UserPlayers.Find(x=>x.playerName=="Platina").Avatar,"Okay.");
		yield return new WaitForSeconds (1);
		Comments.instance.MakeComment ("Phil",GameManager.instance.UserPlayers.Find(x=>x.playerName=="Phil").Avatar,"Ich gebe euch Rückendeckung.");
		yield return new WaitForSeconds (4);
		commenting = false;
	}

	public IEnumerator MissionWinText(){
		if (commenting) {
			//StopCoroutine (TurnOneText ());
		
		}else {
			commenting = true;
			Comments.instance.MakeComment ("Ihr habt gerade einen Unschuldigen erwischt?");
			yield return new WaitForSeconds (3);
			Comments.instance.MakeComment ("Davis", GameManager.instance.UserPlayers.Find (x => x.playerName == "Davis").Avatar, "Wir konnten nicht das Risiko eingehen, dass er sich doch als Feind entpuppt.");
			yield return new WaitForSeconds (4);
			Comments.instance.MakeComment ("Ihr hab den Auftrag die Menschen zu schützen, nicht sie abzuschlachten!");
			yield return new WaitForSeconds (4);
			Comments.instance.MakeComment ("Davis", GameManager.instance.UserPlayers.Find (x => x.playerName == "Davis").Avatar, "Wissen wir, doch dieses Risiko konnten wir gerade nicht eingehen, es gefährdete die gesamte Mission!");
			yield return new WaitForSeconds (4);
			Comments.instance.MakeComment ("Platina", GameManager.instance.UserPlayers.Find (x => x.playerName == "Platina").Avatar, "Konzentriert euch auf den Auftrag.");
			yield return new WaitForSeconds (4);
			Comments.instance.MakeComment ("Davis", GameManager.instance.UserPlayers.Find (x => x.playerName == "Davis").Avatar, "Du hast Recht. Wir können nicht immer warten bis sie zuerst schießen, dafür ist die Gefahr zu hoch.");
			yield return new WaitForSeconds (3);
			Comments.instance.MakeComment ("Deera", GameManager.instance.UserPlayers.Find (x => x.playerName == "Deera").Avatar, "Ein wenig leid tut der arme Kerl mir aber schon in die Schussbahn geraten zu sein.");
			yield return new WaitForSeconds (3);
			//commenting = false;

			Win_Lose_Screen.instance.MissionWon ();
		}
	}



	public void TurnOne(){
		StartCoroutine (TurnOneText ());
	}

	public void CivilKill(){
		StartCoroutine (TurnOneText ());
	}

	public void MissionWin(){
		StartCoroutine (MissionWinText ());
	}

}
