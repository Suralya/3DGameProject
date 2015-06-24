using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TilePath {

	public List<Tile> listOfTiles = new List<Tile>();
	
	public int costOfPath = 0;	
	
	public Tile lastTile;
	
	public TilePath() {}
	
	public TilePath(TilePath tp) {
		listOfTiles = tp.listOfTiles.ToList();
		costOfPath = tp.costOfPath;
		lastTile = tp.lastTile;
	}

	/// <summary>
	/// Adds the tile to list of Tiles and as lastTile.
	/// </summary>
	/// <param name="t">T.</param>
	public void addTile(Tile t) {
		costOfPath += t.APCost;
		listOfTiles.Add(t);
		lastTile = t;
	}
}
