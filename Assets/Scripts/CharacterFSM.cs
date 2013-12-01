using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterFSM : StateMachineBehaviourEx<CharacterFSM.CharacterState> {
	public float speed;

	public enum CharacterState {
		Idle,
		Moving,
		Attacking
	}

	void Start() {
		activeState = CharacterState.Idle;
	}

	public void Move(Vector3 direction) {
		direction.Normalize();
		direction *= speed;
		controller.SimpleMove(direction);
	}
}
