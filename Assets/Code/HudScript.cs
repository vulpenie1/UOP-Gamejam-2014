using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	//private int score1 = 0;
	//private int score2 = 0;
	public GameObject score1;
	public GameObject score2;
	public GameObject currentTeam;

	public Texture2D redStones;
	public Texture2D blueStones;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {


	}

	void OnGUI() {
		UpdateScores ();
		UpdateCurrentPlayer ();
		UpdateStoneCounter ();
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
			currentTeam.guiText.material.color = new Color32( 248, 18, 18, 255 );
		} 
		else {
			currentTeam.guiText.text = "Team 2's turn";
			currentTeam.guiText.material.color = new Color32( 131, 177, 210, 255 );
		}
	}

	private void UpdateStoneCounter() {

		int redOffset = 40;
		int blueOffset = 40;

		//Draw stones for team one
		for (int i = GameManager.TeamOneStonesLeft(); i > 0; i--) {
			GUI.DrawTexture(new Rect( ( Screen.width / 2 ) - 100 + redOffset, ( Screen.height / 2 ) - 260, 32, 32 ), redStones);
			redOffset += 40;
		}

		for (int i = GameManager.TeamTwoStonesLeft(); i > 0; i--) {
			GUI.DrawTexture(new Rect( ( Screen.width / 2 ) - 100 + blueOffset, ( Screen.height / 2 ) - 220, 32, 32 ), blueStones);
			blueOffset += 40;
		}

		redOffset = 0;
		blueOffset = 0;
	}
	
}
