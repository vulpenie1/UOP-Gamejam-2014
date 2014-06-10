using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	public string itemName;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown()
	{
		if ( itemName == "Start Game" )
		{
			Debug.Log("Start Game");
			Application.LoadLevel("dansTest");
		}
		
		else if ( itemName == "Options" )
		{
			Debug.Log("Options Menu");
			Application.LoadLevel("OptionsMenu");
		}
		
		else if ( itemName == "Credits" )
		{
			Debug.Log("Credits");
			Application.LoadLevel("CreditsMenu");
		}	
		
		else if ( itemName == "Exit" )
		{
			Debug.Log("Exit");
			Application.Quit();
		}
		
		else if ( itemName == "Back" )
		{
			Debug.Log("Back");
			Application.LoadLevel("MainMenu");
		}
	}
}
