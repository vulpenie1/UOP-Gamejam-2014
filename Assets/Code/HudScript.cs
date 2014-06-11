using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	//private int score1 = 0;
	//private int score2 = 0;
	public GameObject score1;
	public GameObject score2;
	public GameObject currentTeam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnGUI() {
		UpdateScores ();
		UpdateCurrentPlayer ();

	}

	//A function that updates the display for teams current scores
	private void UpdateScores() {
		int[] scores = GameManager.getScore ();
		score1.guiText.text = "Team 1: " + scores[0].ToString();
		score2.guiText.text = "Team 2: " + scores[1].ToString();
	}

	//A function that updates the display for the current team
	private void UpdateCurrentPlayer() {
		if (GameManager.IsTeamOne ()) {
			currentTeam.guiText.text = "Team 1's turn";
		} 
		else {
			currentTeam.guiText.text = "Team 2's turn";
		}

	}
	
}
