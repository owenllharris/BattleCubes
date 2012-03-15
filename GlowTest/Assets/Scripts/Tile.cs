/// <summary>
/// this is for the tiles
/// it is used to make them glow when that are selectable
/// </summary>

using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	public bool Active = false;		// is the tile selectable
	public bool contansUnit = false;// is there a unit on the tile
	
	public Material glow;		// the glow
	public Material redGlow;	// red Glow
	public Material noGlow;		// no glow
	
	void Start()
	{
		//TODO: check is there is a unit present	
	}
	
	// make the tile glow
	void Activate()
	{
		if(!Active)
		{
			Active = true;				// set it to active
			if(!contansUnit)
				renderer.material = glow;	// change the material
			else
				renderer.material = redGlow;// glow red
			Movement.activeTiles.Add(this.gameObject);
		}
	}
	
	// stop the tile form glowing
	void Deactivate()
	{
		if(Active)
		{
			Active = false;
			renderer.material = noGlow;
		}
	}
	
	// this function highlights all the tiles that a unity can move to
	void HighlightSpaces(int movesLeft)
	{
		// it the unit has moves left
		if(movesLeft > 0)
		{
			movesLeft--;	// subteact a move
			RaycastHit hit;	// the object the ray hits
			
			// hightlight to the left
			if(Physics.Raycast(transform.position, Vector3.left, out hit, 8f))
			{
				if(!hit.transform.gameObject.GetComponent<Tile>().Active)				// if the tile is active
				{
					hit.transform.gameObject.BroadcastMessage("Activate");					// activate the tile
					hit.transform.gameObject.BroadcastMessage("HighlightSpaces", movesLeft);// continue highlighting
				}
			}
		
			// highlight to the right
			if(Physics.Raycast(transform.position, Vector3.right, out hit, 8f))
			{
				if(!hit.transform.gameObject.GetComponent<Tile>().Active)				// if the tile is active
				{
					hit.transform.gameObject.BroadcastMessage("Activate");					// activate the tile
					hit.transform.gameObject.BroadcastMessage("HighlightSpaces", movesLeft);// continue highlighting
				}
			}
		
			// highlight forward
			if(Physics.Raycast(transform.position, Vector3.forward, out hit, 8f))
			{
				if(!hit.transform.gameObject.GetComponent<Tile>().Active)				// if the tile is active
				{
					hit.transform.gameObject.BroadcastMessage("Activate");					// activate the tile
					hit.transform.gameObject.BroadcastMessage("HighlightSpaces", movesLeft);// continue highlighting
				}
			}
			
			// hightlight back
			if(Physics.Raycast(transform.position, Vector3.back, out hit, 8f))
			{
				if(!hit.transform.gameObject.GetComponent<Tile>().Active)				// if the tile is active
				{
					hit.transform.gameObject.BroadcastMessage("Activate");					// activate the tile
					hit.transform.gameObject.BroadcastMessage("HighlightSpaces", movesLeft);// continue highlighting
				}
			}
		}
	}
}
