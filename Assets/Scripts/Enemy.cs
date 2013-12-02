using UnityEngine;

public class Enemy : MonoBehaviour {
	Transform _player;
	CharacterFSM _characterFSM;

	void Start() {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		_characterFSM = GetComponent<CharacterFSM>();
	}

	void FixedUpdate() {
		_characterFSM.Move(_player.position - transform.position);
	}
}
