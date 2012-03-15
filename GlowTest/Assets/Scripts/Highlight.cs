using UnityEngine;
using System.Collections;

public class Highlight : MonoBehaviour {

	public void highlightSpaces(int moves)
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.down, out hit, 10f))
		{
			hit.transform.gameObject.BroadcastMessage("Activate");
			hit.transform.gameObject.BroadcastMessage("HighlightSpaces", moves);
		}
	}
}
