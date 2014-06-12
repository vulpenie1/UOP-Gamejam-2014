using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

	public float newVolume;

	// Use this for initialization
	void Start () {
        newVolume = GameManager.Singleton().getVolume() * 100;
		Debug.Log (newVolume);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		newVolume = GUI.HorizontalSlider(new Rect( ( Screen.width / 2 ) - 150, ( Screen.height / 2 ) , 300, 150), newVolume, 0.0F, 100.0F);

        GameManager.Singleton().setVolume((newVolume));

		GUI.Label( new Rect( ( Screen.width / 2 ) - 40, ( Screen.height / 2 ) - 25 , 300, 25 ), "Volume: " + Mathf.Round( newVolume ) );

	}
}
