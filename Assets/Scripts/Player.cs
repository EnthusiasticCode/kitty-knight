using UnityEngine;

public class Player : CharacterFSM {
	Vector3? _movementInput;

	void Idle_FixedUpdate() {
		if (_movementInput != null) {
			Move(_movementInput.GetValueOrDefault());
			if (_movementInput.Equals(Vector3.zero)) {
				activeState = CharacterState.Moving;
			}
			_movementInput = null;
		}
	}

	void Idle_Update() {
		AllStates_Update();
	}

	void Moving_FixedUpdate() {
		if (_movementInput != null) {
			Move(_movementInput.GetValueOrDefault());
			if (!_movementInput.Equals(Vector3.zero)) {
				activeState = CharacterState.Idle;
			}
			_movementInput = null;
		}
	}
	
	void Moving_Update() {
		AllStates_Update();
	}
	
	void AllStates_Update() {
		if (networkView.isMine) {
			InputMovement();
		}
	}

	void InputMovement() {
		if (_movementInput == null) {
			_movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		}
	}
}
