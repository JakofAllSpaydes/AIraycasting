using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	Rigidbody rbody;

	public Transform mouse;
	Vector3 directionToMouse;

	// Use this for initialization
	void Start () {
	
		rbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (mouse == null) {
			return;
		}

		directionToMouse = mouse.position - transform.position;

		if (Vector3.Angle (transform.forward, directionToMouse) < 90f) {

			Ray catRay = new Ray (transform.position, directionToMouse);
			RaycastHit CatRayHitInfo;

			Debug.DrawRay(transform.position, directionToMouse, Color.red);

			if (Physics.Raycast(catRay, out CatRayHitInfo, 10f)){

				if (CatRayHitInfo.collider.tag == "Mouse"){
					
					if (CatRayHitInfo.distance < 1.5f) {
						Destroy (mouse.gameObject);
					} else {
	
						Debug.Log ("CHASE");

						rbody.AddForce (directionToMouse.normalized * 800f);

				
					}
					}
			}
		}
	}
}
