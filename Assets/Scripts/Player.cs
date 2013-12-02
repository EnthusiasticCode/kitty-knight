using UnityEngine;

public class Player : MonoBehaviour {
	Vector3? _movementInput;
	CharacterFSM _characterFSM;

	void Start() {
		_characterFSM = GetComponent<CharacterFSM>();
	}

	void FixedUpdate() {
		if (_movementInput != null) {
			_characterFSM.Move(_movementInput.GetValueOrDefault());
			_movementInput = null;
		}
	}

	void Update() {
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
