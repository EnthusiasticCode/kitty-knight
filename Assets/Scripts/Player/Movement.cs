using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float movementSpeed;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		Vector3 movement = Vector3.zero;
		if (Input.GetKey (KeyCode.W)) {
			movement += Vector3.forward;
		}
		if (Input.GetKey (KeyCode.A)) {
			movement += Vector3.left;
		}
		if (Input.GetKey (KeyCode.S)) {
			movement += Vector3.back;
		}
		if (Input.GetKey (KeyCode.D)) {
			movement += Vector3.right;
		}

		movement.Normalize ();
		movement *= movementSpeed;

		transform.Translate (movement);
	}
}
