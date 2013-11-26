using UnityEngine;

public class MouseHit : MonoBehaviour {
	public static Transform Target { get; private set; }

	private Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		// When pressing mouse down and no GUI control has been hit
		if (Input.GetMouseButton(0) && GUIUtility.hotControl == 0) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if( Physics.Raycast( ray, out hit, 100 ) && hit.transform == myTransform ) {
				MouseHit.Target = myTransform;
			} else if (MouseHit.Target == myTransform) {
				MouseHit.Target = null;
			}
		} else {
			MouseHit.Target = null;
		}
	}
}
