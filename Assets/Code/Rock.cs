/*
	File:			Rock.cs
	Author:			Krz
	Project:		Curling Game
	Soundtrack:		Station 90 Show 13: Simon Heartfield and Manni Dee
	Description:	The puck-like objects the players hit around
*/

using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
	private float speed;
	public Vector2 velocity;
	
	float ROCK_RADIUS = 3.0f;
	Vector2 BULLSEYE_POSITION = new Vector2(10.0f, 10.0f);


	// Use this for initialization
	void Start () 
	{
		speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += (Vector3)(velocity * speed * Time.deltaTime);
		CollisionCheck();
	}
		
	void HitBy(Rock col)
	{
		Vector2 offset;
		
		offset.x = velocity.normalized.x - col.velocity.normalized.x;
		offset.y = velocity.normalized.y - col.velocity.normalized.y;
		
		velocity -= offset;
	}
	
	float DistanceFromButton()
	{
		Vector2 buttonPos;
		
		buttonPos = GetBullseyePos();
		
		return (velocity - buttonPos).magnitude;
	}
	
	bool IsTouching(Rock otherRock)
	{
		float distance = (otherRock.velocity - velocity).magnitude;
		
		return (distance >= (ROCK_RADIUS * 2.0f));
	}

	Vector2 GetBullseyePos()
	{
		return BULLSEYE_POSITION;
	}

	void CollisionCheck()
	{
		foreach ( Rock rock in FindObjectsOfType<Rock>() )
		{
			if (IsTouching (rock))
			{
				HitBy(rock);
				rock.HitBy(this);
			}
		}
	}
}
