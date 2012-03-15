/// <summary>
/// This takes input form the Controlls and then initates the aproppraite action
/// </summary>

using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour 
{
	public int Moves = 2;	// number of moves
	
	public GameObject currentSpace;	// the space the unit is on
	
	
	
	
	// if the unit is selected
	void YouAreSelected()
	{
		//Start spinning
		BroadcastMessage("StartSpinning");
		
		// Highlight the spaces
		BroadcastMessage("highlightSpaces", Moves);	
	}
	
	// no longer selected
	void NoLongerSelected()
	{
		// stop spinnning
		BroadcastMessage("StopSpinning");	
	}
	
}
