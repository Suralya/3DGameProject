using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActionButtonScript : MonoBehaviour
{

    public Button AimButton, AttackButton, MoveButton;
    public Sprite AimLit, AimUnlit,AttackLit,AttackUnlit,MoveLit,MoveUnlit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming)
	    {
	        AimButton.image.sprite = AimLit;
	        AttackButton.image.sprite = AttackUnlit;
	        MoveButton.image.sprite = MoveUnlit;
	    }
        else if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking)
        {
            AimButton.image.sprite = AimUnlit;
            AttackButton.image.sprite = AttackLit;
            MoveButton.image.sprite = MoveUnlit;
        }
        else if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            AimButton.image.sprite = AimUnlit;
            AttackButton.image.sprite = AttackUnlit;
            MoveButton.image.sprite = MoveLit;
        }
        else
        {
            AimButton.image.sprite = AimUnlit;
            AttackButton.image.sprite = AttackUnlit;
            MoveButton.image.sprite = MoveUnlit;
        }

	}
}
