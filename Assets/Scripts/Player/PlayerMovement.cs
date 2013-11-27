using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float maxVelocity;
	public float maxVelocityChange;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (networkView.isMine) {
			InputMovement();
		}
	}

	private void InputMovement() {
		// Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity *= maxVelocity;
		
		// Apply a force that attempts to reach our target velocity
		Vector3 velocity = rigidbody.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
	}
}
