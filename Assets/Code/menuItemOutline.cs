using UnityEngine;
using System.Collections;

public class menuItemOutline : MonoBehaviour {

	public GameObject outline;

	// Use this for initialization
	void Start () 
	{
		outline.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseEnter()
	{
		Debug.Log("Test");
		outline.renderer.enabled = true;
	}

	void OnMouseLeave()
	{
		Debug.Log("Test");
		outline.renderer.enabled = true;
	}
}
