using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	private int score1 = 0;
	private int score2 = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnGUI() {
		updateScores ();
		updateCurrentPlayer ();

	}

	private void updateScores() {
		int[] scores = GameManager.getScore ();
		score1 = scores [0];
		score2 = scores [1];
		
		GUIText team1Score = GetComponent("Team1Score") as GUIText;
		GUIText team2score = GetComponent("Team2Score") as GUIText;
		team1Score.text = "Team1: " + score1.ToString();
		team2score.text = "Team2: " + score2.ToString();
	}

	private void updateCurrentPlayer() {


	}
	
}
