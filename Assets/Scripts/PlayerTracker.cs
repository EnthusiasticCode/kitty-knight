using UnityEngine;
using System.Collections;

public class PlayerTracker : MonoBehaviour {
	public Transform player;

	public float verticalDistance;
	public float horizontalDistance;

	void LateUpdate() {
		if (player != null) {
			transform.position = new Vector3(
				player.position.x,
				player.position.y + verticalDistance,
				player.position.z + horizontalDistance
			);
		}
	}
}
