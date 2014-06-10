using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private float speed = 50.0f;

	void Start() {
	}
	
	void Update() {
		float dx = Input.GetAxis( "Horizontal" ) * speed;
		float dz = Input.GetAxis( "Vertical" ) * speed;

		Vector3 direction = new Vector3( dx, 0f, dz );
		direction = transform.TransformDirection( direction );
		rigidbody.AddForce( direction );
	}
}