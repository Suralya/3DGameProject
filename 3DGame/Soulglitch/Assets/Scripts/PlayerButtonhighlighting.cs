using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerButtonhighlighting : MonoBehaviour
{

    public Button Player1,Player2,Player3,Player4;
    public Sprite Lit, Unlit;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameManager.instance.UserPlayers[0] ==
	        GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex])
	    {
	        Player1.image.sprite=Lit;
	        Player2.image.sprite = Unlit;
            Player3.image.sprite = Unlit;
            Player4.image.sprite = Unlit;
        }
        else if (GameManager.instance.UserPlayers[1] ==
                 GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex])
        {
            Player1.image.sprite = Unlit;
            Player2.image.sprite = Lit;
            Player3.image.sprite = Unlit;
            Player4.image.sprite = Unlit;   
        }
        else if (GameManager.instance.UserPlayers[2] ==
                 GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex])
        {
            Player1.image.sprite = Unlit;
            Player2.image.sprite = Unlit;
            Player3.image.sprite = Lit;
            Player4.image.sprite = Unlit;
        }
        else if (GameManager.instance.UserPlayers[3] ==
                 GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex])
        {
            Player1.image.sprite = Unlit;
            Player2.image.sprite = Unlit;
            Player3.image.sprite = Unlit;
            Player4.image.sprite = Lit;
        }

	}
}
