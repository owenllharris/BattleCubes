// this script is for laying out the board
// Version 1 - lay out a grid of identical peices


using UnityEngine;
using System.Collections;


public class BuildBoard : MonoBehaviour {
	
	public Object tile;				// this is the tile that makes up the board
	
	public int Width = 10;			// the board Width, can be changed in editor
	public int Length = 10;			// the board length, can be changed in editor
	
	private float tileY = -10;		// the height of the tiles
	
	public GameObject BoardHolder;	// this is an object that holds all the board tiles
	
	// Use this for initialization
	void Start () 
	{
		// build the board
		for (float i = 0; i < Width; i++) 
		{
			for (int j = 0; j < Length; j++) 
			{
				// create a tile
				GameObject clone = Instantiate(tile, new Vector3(i*10f, tileY, j* 10f), Quaternion.identity) as GameObject;
				// add it to the board holder
				clone.gameObject.transform.parent = BoardHolder.transform;
			}
				
		}
	}
	

	
}
