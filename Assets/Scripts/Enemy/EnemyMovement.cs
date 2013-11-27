using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public float maxVelocity;
	public float maxVelocityChange;

	private Transform player;

	// Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update() {
		// Calculate how fast we should be moving
		Vector3 targetVelocity = (player.position - transform.position).normalized * maxVelocity;

		// Apply a force that attempts to reach our target velocity
		Vector3 velocity = rigidbody.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
	}
}
