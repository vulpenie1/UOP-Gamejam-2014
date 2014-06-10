/*
	File:			FSM.cs
	Author:			Krz
	Project:		Curling Game
	Soundtrack:		Fnoob Techno Radio
	Description:	Manages the camera switching
*/

using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour
{
	public Camera playerCam;
	public Camera rockCam;

	public enum eGameState
	{
		ePlayer=0,
		eRock,
	};

    public eGameState mGameState;

	void Start ()
	{
		ChangeState (eGameState.ePlayer);
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
