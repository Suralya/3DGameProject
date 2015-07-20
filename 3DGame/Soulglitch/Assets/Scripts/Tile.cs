using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Tile : MonoBehaviour
{

    public int AptoCurrPlayer=0;

	public Vector2 gridPosition = Vector2.zero;

	public int APCost = 1;
	public bool impassible = false;

	public bool occupied=false;
	
	public List<Tile> neighbors = new List<Tile>();

	public GameManager GM ;

	// Use this for initialization
	void Start () {
		if (impassible) {
			//transform.GetComponent<Renderer> ().material.color = Color.magenta;
		}
		gridPosition.x = this.transform.position.x;
		gridPosition.y = this.transform.position.z;

	}

	/// <summary>
	/// Gets the neighbors.
	/// </summary>
	public void getNeighbors(){
		neighbors=(GM.map.FindAll(
			delegate(Tile obj) {
			return   ((gridPosition.x+1==obj.gridPosition.x&&gridPosition.y==obj.gridPosition.y)
			       ||(gridPosition.x==obj.gridPosition.x&&gridPosition.y+1==obj.gridPosition.y)
			       ||(gridPosition.x==obj.gridPosition.x&&gridPosition.y-1==obj.gridPosition.y)
			       ||(gridPosition.x-1==obj.gridPosition.x&&gridPosition.y==obj.gridPosition.y)
			          );
		}
		));
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.UserPlayers.Any (delegate(Player obj) {return obj.gridPosition == gridPosition;})&&GameManager.instance.UserPlayers[GameManager.instance.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition)].HP>0 
		   || GM.AIPlayers.Any (delegate(Player obj) {return obj.gridPosition == gridPosition;})) 
		{
			occupied = true;
		} else {
			occupied = false;
		}



	}

	/// <summary>
	/// Manages color while hovering over tile.
	/// </summary>
	void OnMouseEnter(){
        if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            AptoCurrPlayer =
                TilePathFinder.FindPath(GameManager.instance.map.Find(x => GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].gridPosition == x.gridPosition), this).Count;
        }


		if (transform.GetComponent<Renderer> ().material.color == Color.white && !impassible 
            && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
            && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
            && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
			transform.GetComponent<Renderer> ().material.color = Color.cyan;
		}



        else if (transform.GetComponent<Renderer>().material.color == Color.blue && !impassible
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                 && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            transform.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (transform.GetComponent<Renderer>().material.color == Color.white && !impassible
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
        && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            transform.GetComponent<Renderer>().material.color = Color.black;
        }




        else if (transform.GetComponent<Renderer>().material.color == Color.red && !impassible
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                 && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
                 &&!GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.healing)
        {
            transform.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (transform.GetComponent<Renderer>().material.color == Color.white && !impassible
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
        && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.healing)
        {
            transform.GetComponent<Renderer>().material.color = Color.black;
        }





        else if (transform.GetComponent<Renderer>().material.color == Color.yellow && !impassible
                && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
                && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.healing)
        {
            transform.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (transform.GetComponent<Renderer>().material.color == Color.white && !impassible
                && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
                && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.healing)
        {
            transform.GetComponent<Renderer>().material.color = Color.black;
        } 




        else if (transform.GetComponent<Renderer>().material.color == Color.magenta && !impassible
                 && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            transform.GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (transform.GetComponent<Renderer>().material.color == Color.white && !impassible
              && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
              && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
              && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            transform.GetComponent<Renderer>().material.color = Color.black;
        } 
		//Debug.Log ("my position is (" + gridPosition.x +","+gridPosition.y+")");
	}

	/// <summary>
	/// Manages color exit hovering over tile.
	/// </summary>
	void OnMouseExit(){
        if (transform.GetComponent<Renderer>().material.color == Color.cyan && !impassible
            && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
            && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
            && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        }



        else if (transform.GetComponent<Renderer>().material.color == Color.cyan && !impassible
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                 && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            transform.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (transform.GetComponent<Renderer>().material.color == Color.black && !impassible
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
        && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        }




        else if (transform.GetComponent<Renderer>().material.color == Color.cyan && !impassible
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                 && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.healing)
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (transform.GetComponent<Renderer>().material.color == Color.black && !impassible
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
        && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
        && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.healing)
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        }





        else if (transform.GetComponent<Renderer>().material.color == Color.cyan && !impassible
                && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
                && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.healing)
        {
            transform.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (transform.GetComponent<Renderer>().material.color == Color.black && !impassible
                && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving
                && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].Weapon.healing)
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        }




        else if (transform.GetComponent<Renderer>().material.color == Color.cyan && !impassible
                 && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
                 && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            transform.GetComponent<Renderer>().material.color = Color.magenta;
        }
        else if (transform.GetComponent<Renderer>().material.color == Color.black && !impassible
              && GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming
              && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking
              && !GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].moving)
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        } 
	}

	/// <summary>
	/// Manages events on mouse on up.
	/// </summary>
	void OnMouseUp() {
		if (GM.UserPlayers [GM.currentPlayerIndex].moving) {
			GM.moveCurrentPlayer (this);
			Debug.Log ("Wurde übergebn"+this.transform.position.x+","+this.transform.position.z);
		} else if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].attacking) {
			GameManager.instance.attackWithCurrentPlayer(this);
			Debug.Log ("Angriff auf"+this.transform.position.x+","+this.transform.position.z);
	}
		else if (GameManager.instance.UserPlayers[GameManager.instance.currentPlayerIndex].aiming) {
			GameManager.instance.aimWithCurrentPlayer(this);
			Debug.Log ("Aiming"+this.transform.position.x+","+this.transform.position.z);
		}else if(!GM.UserPlayers[GM.currentPlayerIndex].moving
		         &&!GM.UserPlayers[GM.currentPlayerIndex].attacking
		         &&!GM.UserPlayers[GM.currentPlayerIndex].aiming
		         &&GM.UserPlayers.Any(t=>t.gridPosition==this.gridPosition)
		         &&GM.UserPlayers[GM.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition)].HP>0){
			GameManager.instance.formerPlayerIndex=GameManager.instance.currentPlayerIndex;
			GM.UserPlayers[GM.currentPlayerIndex].selected=false;
			GM.currentPlayerIndex=GM.UserPlayers.FindIndex(t=>t.gridPosition==this.gridPosition);
			GM.UserPlayers[GM.currentPlayerIndex].selected=true;
			CameraCenteronCurrent.instance.CamonCurent();

		}
}

}