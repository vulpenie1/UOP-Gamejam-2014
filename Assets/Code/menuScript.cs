using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	public string itemName;
	public GameObject menuOutline;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		if ( itemName == "start game" )
		{
			Debug.Log("Start Game");
			Application.LoadLevel("dansTest");
		}

		else if ( itemName == "options" )
		{
			Debug.Log("Options");
			Application.LoadLevel("optionsMenu");
		}

		else if ( itemName == "credits" )
		{
			Debug.Log("Credits");
			Application.LoadLevel("creditsMenu");
		}

		else if ( itemName == "exit" )
		{
			Debug.Log("Exit");
			Application.Quit();
		}

		else if ( itemName == "back" )
		{
			Debug.Log("back");
			Application.LoadLevel("mainMenu");
		}
	}

	void OnMouseEnter()
	{
		if ( itemName == "start game" )
		{
			Instantiate( menuOutline, transform.position, transform.rotation );
		}
		
		else if ( itemName == "options" )
		{
			Instantiate( menuOutline, transform.position, transform.rotation );
		}
		
		else if ( itemName == "credits" )
		{
			Instantiate( menuOutline, transform.position, transform.rotation );
		}
		
		else if ( itemName == "exit" )
		{
			Instantiate( menuOutline, transform.position, transform.rotation );
		}

		else if ( itemName == "back" )
		{
			Instantiate( menuOutline, transform.position, transform.rotation );
		}
	}

	void OnMouseExit()
	{
		Destroy( GameObject.FindWithTag("menuOutline") );
	}
}
