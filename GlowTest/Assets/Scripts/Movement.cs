/// <summary>
/// Moves the unit to the selected destination
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	
	
	public GameObject boardHolder;
	
	

	
	static public List<GameObject> activeTiles = new List<GameObject>();
	
	void Start()
	{
		// boardHolder.BroadcastMessage();	
	}
	
	static public void move(GameObject Unit, GameObject Destination)
	{
		// move the unit
		Unit.transform.position = new Vector3(Destination.transform.position.x, 
		                                      Destination.transform.position.y + 10f, 
		                                      Destination.transform.position.z);
		
		// deactivate all the sellected tiles
		for (int i = 0; i < activeTiles.Count; i++) 
		{
			activeTiles[i].BroadcastMessage("Deactivate");
		}
		
		
		
	}
}
