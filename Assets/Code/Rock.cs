/*
	File:			Rock.cs
	Author:			Krz
	Project:		Curling Game
	Soundtrack:		Station 90 Show 13: Simon Heartfield and Manni Dee
	Description:	The puck-like objects the players hit around
*/

using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour
{
    public GameManager.eTeam team;


    float ROCK_RADIUS = 3.0f;
    Vector3 BULLSEYE_POSITION = new Vector3(10.0f, 10.0f, 10.0f);


    public float DistanceFromBullseye()
    {
        return (transform.position - GetBullseyePos()).magnitude;
    }


    private Vector3 GetBullseyePos()
    {
        return BULLSEYE_POSITION;
    }
}