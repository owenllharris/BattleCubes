/// <summary>
/// Simple script for rotating an object
/// </summary>

using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float upSpeed = 1f;
	public float leftSpeed = 1f;
	
	public bool iAmSpinning = false;
	
	// Update is called once per frame
	void Update () 
	{
		if(iAmSpinning)
		{
			transform.Rotate(Vector3.up * upSpeed);
			transform.Rotate(Vector3.left * leftSpeed);
		}
	}
	
	void StopSpinning()
	{
		iAmSpinning = false;	
	}
	
	void StartSpinning()
	{
		iAmSpinning = true;
	}
	
	
}
