﻿using UnityEngine;
using System.Collections;

public class optionsMenu : MonoBehaviour {

	public float newVolume;

	// Use this for initialization
	void Start () {
		newVolume = PlayerPrefs.GetFloat ("volume") * 100;
		Debug.Log (newVolume);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		newVolume = GUI.HorizontalSlider(new Rect( ( Screen.width / 2 ) - 150, ( Screen.height / 2 ) , 300, 150), newVolume, 0.0F, 100.0F);

		PlayerPrefs.SetFloat ( "volume", ( newVolume / 100 ) );//badly inefficiant
		PlayerPrefs.Save ();

		GUI.Label( new Rect( ( Screen.width / 2 ) - 50, ( Screen.height / 2 ) - 25 , 300, 25 ), "Volume: " + newVolume);

	}
}