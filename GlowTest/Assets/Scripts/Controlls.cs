/// <summary>
/// Collect player input
/// Discern what the player is touching and initiate the apropriate action
/// </summary>

using UnityEngine;
using System.Collections;

public class Controlls : MonoBehaviour {
	
	public GameObject cube;			// a unit in the field, used for early prototyping
	public GameObject ActiveUnit;	// the unit currently selected
	
	enum thingsToSelect { tile = 0, cube = 1}		// the different tyoes of things the player can interact with
	thingsToSelect SelectedThing;					// the currently selected object
		
	// Update is called once per frame
	void Update () 
	{
		// when the player clicks
		if(Input.GetMouseButton(0))
		{
			// run the click function
			click();	
		}
	}
	
	public void click()
	{
		// this is uses to see what the player has clicked on and initate action
		
		//create a ray that shoots what ever the player touches
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit thingIHit;							// the object the ray hits
		if(Physics.Raycast(ray, out thingIHit, 200f))	// shoot the ray and see if it hits anything
		{
			// see what the ray has hit
			switch(thingIHit.transform.gameObject.tag)
			{
			case "tile":
				// the player is touching a tile
				
				SelectedThing = thingsToSelect.tile;							// set the currently settected object
				if(thingIHit.transform.gameObject.GetComponent<Tile>().Active)	// if the tile is one that can be moved to 
					Movement.move(ActiveUnit, thingIHit.transform.gameObject);	// Initiate the move command on the active unit
				
				// old code 
				//thingIHit.transform.gameObject.renderer.material = glow;
				//thingIHit.transform.gameObject.BroadcastMessage("Activate");
				//Instantiate(cube, new Vector3(thingIHit.transform.position.x, thingIHit.transform.position.y + 10f, thingIHit.transform.position.z), Quaternion.identity);
				break;
				
			case "cube":
				// the player has touched a unit
				ActiveUnit.BroadcastMessage("NoLongerSelected");	// de sellect the previous active Unit
				
				ActiveUnit = thingIHit.transform.gameObject;		// set the newly selected object to the active unit
				ActiveUnit.BroadcastMessage("YouAreSelected");		// tell the unit it has been selected
				
				SelectedThing = thingsToSelect.cube;				//set the currently selected type to cube
				break;
			}			
		}
	}
}
