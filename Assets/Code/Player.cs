using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject rock;
	//public eTeam team;

	private float speed =		50.0f;
	private float shootSpeed =	18.0f;
	private float sensitivity =	4.2f;

	private bool canShoot = true;

	void Start() {
		rock.transform.parent = transform;
	}

	void Update() {
		Move();
		Look();
		ShootRock();
	}

	public void Move() {
		float dx =				Input.GetAxis( "Horizontal" ) * speed;
		float dz =				Input.GetAxis( "Vertical" ) * speed;

		dx =					Mathf.Clamp( dx, -speed, speed );
		dz =					Mathf.Clamp( dz, -speed, speed );

		Vector3 direction =		new Vector3( dx, 0f, dz );
		direction =				transform.TransformDirection( direction );

		rigidbody.AddForce( direction );
	}

	public void Look() {
		float dx = Input.GetAxis( "Mouse Y" ) * sensitivity;
		transform.Rotate( 0f, -dx, 0f );
	}

	public void ShootRock() {
		if ( Input.GetMouseButtonDown( 0 ) && canShoot ) {
			canShoot = false;

			rock.transform.parent = null;

			Vector3 forwardForce = transform.forward;
			forwardForce *= ( speed * shootSpeed );

			rock.rigidbody.AddForce( forwardForce );
		}
	}
}