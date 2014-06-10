using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	public string name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if ( name == "start game" )
		{
			Debug.Log("Start Game");
			Application.LoadLevel("dansTest");
		}

		if ( name == "options" )
		{
			Debug.Log("Options");
			Application.LoadLevel("optionsMenu");
		}


		if ( name == "credits" )
		{
			Debug.Log("Credits");
			Application.LoadLevel("creditsMenu");
		}


		if ( name == "exit" )
		{
			Debug.Log("Exit");
			Application.Quit();
		}


	}
}
