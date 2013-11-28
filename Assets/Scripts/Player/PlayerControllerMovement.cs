using UnityEngine;
using System.Collections;

public class PlayerControllerMovement : MonoBehaviour {
	public float speed;

	private CharacterController _controller;

	private Vector3? _nextMovement;
	
	// Use this for initialization
	void Start() {
		_controller = this.GetComponent<CharacterController>();
	}
	
	// FixedUpdate is called once per physics cycle
	void FixedUpdate() {
		if (_nextMovement != null) {
			_controller.SimpleMove(_nextMovement.GetValueOrDefault());
			_nextMovement = null;
		}
	}

	// Update is called once per frame
	void Update() {
		if (networkView.isMine) {
			InputMovement();
		}
	}

	private void InputMovement() {
		if (_nextMovement == null) {
			_nextMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			_nextMovement.GetValueOrDefault().Normalize();
			_nextMovement *= speed;
		}
	}
}
