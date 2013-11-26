using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float movementSpeed;

	private CharacterController controller;

	// Use this for initialization
	void Start() {
		controller = (CharacterController)GetComponent("CharacterController");
	}

	// Update is called once per frame
	void Update() {
		if (networkView.isMine) {
			InputMovement();
		}
	}

	private void InputMovement() {
		Vector3 movement = Vector3.zero;
		movement += Vector3.forward * Input.GetAxis("Vertical");
		movement += Vector3.right * Input.GetAxis("Horizontal");
		movement.Normalize();
		movement *= movementSpeed;
		
		controller.SimpleMove(movement);
	}
}
