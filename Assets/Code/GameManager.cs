using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject stonesDeposit;
	public static float volume = PlayerPrefs.GetFloat ("volume");

	void Awake() {
		volume = PlayerPrefs.GetFloat ("volume");
		//volume = 1.0f;
	}
	
	void Update() {	
		if ( Input.GetKeyUp( KeyCode.Escape ) )
		{
			Application.LoadLevel("mainMenu");
		}
	}

	public enum eTeam {
		TEAM_1,
		TEAM_2
	}

	private static GameManager gm;
	public static GameManager Singleton() {
		if ( !gm ) {
			gm = FindObjectOfType<GameManager>();
		}

		return gm;
	}

	public static float getVolume()
	{
		return volume;
	}

	public static void setVolume( float newVolume )
	{
		volume = newVolume / 100;
		PlayerPrefs.SetFloat ("volume", volume );
		PlayerPrefs.Save();
	}
}