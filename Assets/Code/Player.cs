﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject rock;
	public GameManager.eTeam team;
	public GameObject camera;

	private float speed =			0.0f;
	private float acceleration =	0.001f;
	private const float MAX_SPEED =	50.0f;
	private float shootSpeed =		25.0f;
	private float sensitivity =		4.2f;
	private bool canShoot =			true;

	private GameObject stoneClone;

	void Start() {
		GiveStone();
	}

	void Update() {
		Move();
		Look();
		ShootStone();

		if ( speed > 0 ) {
			speed -= acceleration;
		}
	}

	public void Move() {
		float dx =				Input.GetAxis( "Horizontal" ) * speed;
		float dz =				Input.GetAxis( "Vertical" ) * speed;

		dx =					Mathf.Clamp( dx, -speed, speed );
		dz =					Mathf.Clamp( dz, -speed, speed );

		Vector3 direction =		new Vector3( dx, 0f, dz );
		direction =				transform.TransformDirection( direction );

		// rigidbody.AddForce( direction );
		transform.Translate( direction, Space.World );

		if ( speed < MAX_SPEED ) {
			speed += acceleration;
		}
	}

	public void Look() {
		float dx = Input.GetAxis( "Mouse Y" ) * sensitivity;
		transform.Rotate( 0f, -dx, 0f );
	}

	public void GiveStone() {
		Vector3 clonePos = transform.position;
		clonePos.z += 1.5f;

		stoneClone = (GameObject) Instantiate( rock, clonePos, Quaternion.identity );
		stoneClone.transform.parent = transform;
	}

	public void ShootStone() {
		if ( Input.GetMouseButtonDown( 0 ) && canShoot ) {
			canShoot = false;

			stoneClone.transform.parent = null;
			camera.transform.parent = stoneClone.transform;

			Vector3 forwardForce = transform.forward;
			forwardForce *= ( shootSpeed * shootSpeed );

			stoneClone.rigidbody.AddForce( forwardForce );
		}
	}
}