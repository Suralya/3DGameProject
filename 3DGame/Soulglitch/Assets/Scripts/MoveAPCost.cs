using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAPCost {

    public MoveAPCost()
    {
    }

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int WayApCost(Tile originTile, Tile destinationTile)
    {
        return TilePathFinder.FindPath(originTile, destinationTile).Count;
    }

}
