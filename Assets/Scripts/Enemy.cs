using UnityEngine;

public class Enemy : CharacterFSM {
	Transform _player;

	override protected void OnAwake() {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Idle_FixedUpdate() {
		activeState = CharacterState.Moving;
		Move(_player.position - transform.position);
	}

	void Moving_FixedUpdate() {
		Idle_FixedUpdate();
	}
}
