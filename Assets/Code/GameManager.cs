using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	void Awake() {
	}
	
	void Update() {	
	}

	enum eTeam {
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
}