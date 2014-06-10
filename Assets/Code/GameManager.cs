/*
	File:			GameManager.cs
	Author:			Krz, Dan
	Project:		Curling Game
	Soundtrack:		Station 90 Show 13: Simon Heartfield and Manni Dee
	Description:	Manages the state of the game.
*/

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
<<<<<<< HEAD
	public GameObject stoneDeposit;
=======
    static Vector2 BULLSEYE_POSITION = new Vector2(10.0f, 10.0f);
    static private int team1score = 0, team2score = 0;
    public GameObject stonesDeposit;
    public Camera playerCam;
    public Camera rockCam;
    private eGameState mGameState;
    
    public enum eGameState
    {
        ePlayer = 0,
        eRock,
    };
>>>>>>> 331a32c79cf4d63090b38f18d7756429fccbda48

    void Awake()
    {
        Screen.lockCursor = true;
        Screen.showCursor = false;
        ChangeState(eGameState.ePlayer);
	}
	
	void Update() {	
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


    static void UpdateScores()
    {
        eTeam winningTeam = GetRoundWinner();
        float nmeDistanceFromBullseye = GetNMEClosestToBullseye(winningTeam);
        GivePoints(winningTeam, nmeDistanceFromBullseye);
    }

    static eTeam GetRoundWinner()
    {
        eTeam winningTeam = 0;
        float winningDistance = 99999.9f;

        foreach (Rock rock in FindObjectsOfType<Rock>())
        {
            if (rock.DistanceFromBullseye() < winningDistance)
            {
                winningTeam = rock.team;
                winningDistance = rock.DistanceFromBullseye();
            }
        }

        return winningTeam;
    }

    static float GetNMEClosestToBullseye(eTeam winningTeam)
    {
        float closestToBullseye = 99999.9f;
        foreach (Rock rock in FindObjectsOfType<Rock>())
        {
            if (rock.team != winningTeam)
            {
                if (rock.DistanceFromBullseye() < closestToBullseye)
                {
                    closestToBullseye = rock.DistanceFromBullseye();
                }
            }
        }

        return closestToBullseye;
    }

    static private void GivePoints(eTeam winningTeam, float nmeDistanceFromBullseye)
    {
        int points = 0;

        foreach (Rock rock in FindObjectsOfType<Rock>())
        {
            if (rock.team == winningTeam)
            {
                if (rock.DistanceFromBullseye() < nmeDistanceFromBullseye)
                {
                    points++;
                }
            }
        }
        GiveWinningTeamPoints(winningTeam, points);
    }

    static private void GiveWinningTeamPoints(eTeam team, int points)
    {
        switch (team)
        {
            case eTeam.TEAM_1:
                {
                    team1score += points;
                    break;
                }
            case eTeam.TEAM_2:
                {
                    team2score += points;
                    break;
                }
        }
    }

    public void ChangeState(eGameState state)
    {
        mGameState = state;

        if (state == eGameState.ePlayer)
        {
            playerCam.enabled = true;
            rockCam.enabled = false;
        }

        if (state == eGameState.eRock)
        {
            playerCam.enabled = false;
            rockCam.enabled = true;
        }
    }
}