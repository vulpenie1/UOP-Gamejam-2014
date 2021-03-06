﻿using UnityEngine;
using System.Collections;

public class MouseTest : MonoBehaviour {
	
	static float _SCRUBTIME = 10f;
	static int _SCREENHEIGHT = Screen.height;
	static int _SCREENWIDTH = Screen.width;
	
	//y mouse position coords
	float MousePositionY;
	
	//get scrub motion
	bool bottomClip;
	bool topClip;
	
	//elapsed time
	float timeElapse = 0;
	//Overall scrub elapsed time
	float scrubValue = 0;
	//per scrub elapsed time
	float scrubPercent = 0;
	//start animating
	float scrubFinal = 100;
	
	// Use this for initialization
	void Start () {
		
	}
	//debug gui
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,110), "Y: " + MousePositionY.ToString()
		        + "\n topClip: " + topClip
		        + "\n bottomClip: " + bottomClip
		        + "\n timeElapse: " + timeElapse
		        + "\n scrub: " + scrubValue
		        + "\n scrub%: " + scrubPercent
		        + "\n scrub%: " + scrubPercent);
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		MousePositionY = Input.mousePosition.y;
		
		//Get clipping
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
		
		animationSpeed(scrubFinal);
		
		//bleed off
		if (scrubFinal <= 0)
		{
			scrubFinal = 0;
		}
		else
		{
			scrubFinal -= 0.5f;
		}
	}
	
	//change scrub animation speed by % of passed value.
	void animationSpeed(float scrubPercent)
	{
		//play vareity of animations
		if ((scrubPercent / 75) > 110f)
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
}
