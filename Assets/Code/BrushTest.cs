﻿using UnityEngine;
using System.Collections;

public class BrushTest : MonoBehaviour {
	
	static float _SCRUBTIME = 10f;
	static int _SCREENHEIGHT = Screen.height;
	static int _SCREENWIDTH = Screen.width;
	
	//x/y mouse position coords
	float MousePositionY;
	float MousePositionX;
	
	//get scrub motion
	bool bottomClip;
	bool topClip;
	bool leftClip;
	bool rightClip;
	
	//elapsed time
	float timeElapse = 0;
	//Overall scrub elapsed time
	float scrubValue = 0;
	//per scrub elapsed time
	float scrubPercent = 0;
	//start animating
	float scrubFinal = 100;

	Vector3 scrubVector = new Vector3(0, 0, 0);
	
	// Use this for initialization
	void Start () {
		
	}
	//debug gui
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,160,160), "Y: " + MousePositionY.ToString()
		        + "\n topClip: " + topClip
		        + "\n bottomClip: " + bottomClip
		        + "\n leftClip: " + leftClip
		        + "\n rightClip: " + rightClip
		        + "\n timeElapse: " + timeElapse
		        + "\n scrub: " + scrubValue
		        + "\n scrub%: " + scrubPercent
		        + "\n scrub% / 0.075: " + scrubPercent * 0.75
		        + "\n scrub Vector: " + scrubVector);
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		MousePositionY = Input.mousePosition.y;
		MousePositionX = Input.mousePosition.x;

		//Get clipping NS
		if (MousePositionY > _SCREENHEIGHT / 2)
		{
			topClip = true;
			bottomClip = false;
		}
		if (MousePositionY < _SCREENHEIGHT / 2)
		{
			topClip = false;
			bottomClip = true;
		}
		//EW
		if (MousePositionX > _SCREENWIDTH / 2)
		{
			rightClip = true;
			leftClip = false;
		}
		if (MousePositionX < _SCREENWIDTH / 2)
		{
			rightClip = false;
			leftClip = true;
		}

		//scrub X axis
		scrubX();
		scrubY();

		
		animationSpeed(scrubFinal);
		setFriction(scrubFinal);
		
		//bleed off
		if (scrubFinal <= 0)
		{
			scrubFinal = 0;
			scrubVector.x = 0;
		}
		else
		{
			scrubFinal -= 0.5f;
			scrubVector.x -= 0.5f;
		}
	}
	
	//change scrub animation speed by % of passed value.
	void animationSpeed(float scrubPercent)
	{
		//play vareity of animations
		if ((scrubPercent * 0.75) > 110f)
		{
			//max out animation - so no crazy speeds
			//animation["Running"].speed = 120f;
		}
		else if (scrubPercent > 0)
		{
			//normal
			//animation["Running"].speed = scrubPercent / 75;
		}
		else
		{
			//no motion - play idle animation
		}
	}

	void setFriction(float scrubPercent)
	{
		if ((scrubPercent * 0.075) > 1.0f)
		{
			//pass max 1
			//GameManager.Singleton().SetFriction(0);
		}
		else
		{
			//GameManager.Singleton().SetFriction(1.0f - scrubPercent);
		}
	}

	void scrubX()
	{
		//get scrub power
		if (topClip == true)
		{
			timeElapse += Time.deltaTime;
			scrubPercent = 10 - (timeElapse * 100);
			if (scrubPercent < 0)
			{
				scrubPercent = 0;
			}
		}
		
		//reset
		if (topClip == false)
		{
			//count total scrub elapsed time
			scrubValue += timeElapse;
			
			scrubFinal += scrubPercent;
			scrubVector.x = scrubFinal;
			
			//bleed off scrub percent
			if (scrubPercent <= 0)
			{
				scrubPercent = 0;
			}
			else
			{
				scrubPercent -= 0.5f;
				
			}
			
			//reset
			timeElapse = 0;
		}
	}

	void scrubY()
	{

	}
}
