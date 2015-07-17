using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileHighlight {

	public TileHighlight () {
		
	}

	/// <summary>
	/// Finds the Tiles to highlight.
	/// </summary>
	/// <returns>The highlight.</returns>
	/// <param name="originTile">Origin.</param>
	/// <param name="movementPoints">Range.</param>
	public static List<Tile> FindHighlight(Tile originTile, int movementPoints) {
		List<Tile> closed = new List<Tile>();
		List<TilePath> open = new List<TilePath>();
		
		TilePath originPath = new TilePath();
		originPath.addTile(originTile);
		
		open.Add(originPath);
		
		while (open.Count > 0) {
			TilePath current = open[0];
			open.Remove(open[0]);
			
			if (closed.Contains(current.lastTile)) {
				continue;
			} 
			if (current.costOfPath > movementPoints + 1) {
				continue;
			}
			
			closed.Add(current.lastTile);
			
			foreach (Tile t in current.lastTile.neighbors) {	
				if (t.impassible||t.occupied) continue;
				TilePath newTilePath = new TilePath(current);
				newTilePath.addTile(t);
				open.Add(newTilePath);
			}
		}
		closed.Remove(originTile);
		return closed;
	}


	public static List<Tile> FindAIMoveHighlight(Tile originTile, int movementPoints) {
		List<Tile> closed = new List<Tile>();
		List<TilePath> open = new List<TilePath>();
		
		TilePath originPath = new TilePath();
		originPath.addTile(originTile);
		
		open.Add(originPath);
		
		while (open.Count > 0) {
			TilePath current = open[0];
			open.Remove(open[0]);
			
			if (closed.Contains(current.lastTile)) {
				continue;
			} 
			if (current.costOfPath > movementPoints + 1) {
				continue;
			}
			
			closed.Add(current.lastTile);
			
			foreach (Tile t in current.lastTile.neighbors) {	
				if (t.impassible) continue;
				TilePath newTilePath = new TilePath(current);
				newTilePath.addTile(t);
				open.Add(newTilePath);
			}
		}
		closed.Remove(originTile);
		return closed;
	}

	/// <summary>
	/// Finds Tiles to Highlight for attack.
	/// </summary>
	/// <returns>The atack highlight.</returns>
	/// <param name="originTile">Player position.</param>
	/// <param name="movementPoints">Range.</param>
	public static List<Tile> FindAtackHighlight(Tile originTile, int movementPoints) {
		List<Tile> closed = new List<Tile>();
		List<TilePath> open = new List<TilePath>();
		
		TilePath originPath = new TilePath();
		originPath.addTile(originTile);
		
		open.Add(originPath);
		
		while (open.Count > 0) {
			TilePath current = open[0];
			open.Remove(open[0]);
			
			if (closed.Contains(current.lastTile)) {
				continue;
			} 
			if (current.costOfPath > movementPoints + 1) {
				continue;
			}
			
			closed.Add(current.lastTile);
			
			foreach (Tile t in current.lastTile.neighbors) {	
				//if (t.impassible) continue;
				TilePath newTilePath = new TilePath(current);
				newTilePath.addTile(t);
				open.Add(newTilePath);
			}
		}
		closed.Remove(originTile);
		return closed;
	}
}
