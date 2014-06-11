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
    private Player player;
    public GameManager.eTeam team;
    public Camera rockCamera;

    private bool inSupply, isPickedUp;

    Vector3 BULLSEYE_POSITION = new Vector3(10.0f, 10.0f, 10.0f);

    void Start()
    {
        inSupply = true;
        isPickedUp = false;
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
    }

    public float DistanceFromBullseye()
    {
        return (transform.position - GetBullseyePos()).magnitude;
    }


    private Vector3 GetBullseyePos()
    {
        return BULLSEYE_POSITION;
    }

    public void Pickup()
    {
        inSupply =      false;
        isPickedUp =    true;
    }

    public void Fire()
    {
        isPickedUp = false;
        rigidbody.velocity = player.rigidbody.velocity;
    }

    public bool InSupply()
    {
        return inSupply;
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }
}