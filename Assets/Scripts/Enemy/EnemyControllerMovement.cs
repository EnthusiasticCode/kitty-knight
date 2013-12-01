using UnityEngine;
using System.Collections;

public class EnemyControllerMovement : MonoBehaviour {
	public float speed;

	private Transform _player;
	private Transform _transform;
	private CharacterController _controller;

	// Use this for initialization
	void Start() {
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		_transform = this.GetComponent<Transform>();
		_controller = this.GetComponent<CharacterController>();
	}
	
	// FixedUpdate is called once per physics cycle
	void FixedUpdate() {
		_controller.SimpleMove((_player.position - _transform.position).normalized * speed);
	}
}
