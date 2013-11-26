using UnityEngine;

public class MoveOnMouseClick : MonoBehaviour {
	private Transform myTransform;				// this transform
	private Vector3 destinationPosition;		// The destination Point
	private float destinationDistance;			// The distance between myTransform and destinationPosition
	
	public float moveSpeed;						// The Speed the character will move

	void Start () {
		myTransform = transform;							// sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;			// prevents myTransform reset
	}
	
	void Update () {
		
		// keep track of the distance between this gameObject and destinationPosition
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
		
		if(destinationDistance < .5f){		// To prevent shakin behavior when near destination
			moveSpeed = 0;
		}
		else if(destinationDistance > .5f){			// To Reset Speed to default
			moveSpeed = 3;
		}
		
		// Moves the player if the mouse button is hold down
		if (Input.GetMouseButton(0)&& GUIUtility.hotControl ==0) {
			
			Plane playerPlane = new Plane(Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float hitdist = 0.0f;
			
			if (playerPlane.Raycast(ray, out hitdist)) {
				Vector3 targetPoint = ray.GetPoint(hitdist);
				if (MouseHit.Target != null) {
					destinationPosition = myTransform.position;
				} else {
					destinationPosition = targetPoint;
				}
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				myTransform.rotation = targetRotation;
			}
		}
		
		// To prevent code from running if not needed
		if(destinationDistance > .5f){
			myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		}
	}
}