using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody rbody;

	public float moveSpeed;
	public float randomizer;


	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		rbody.velocity = transform.forward * moveSpeed + Physics.gravity;

		Ray moveRay = new Ray (transform.position, transform.forward);

		Debug.DrawRay (transform.position, moveRay.direction*1.25f, Color.yellow);
		if (Physics.SphereCast (moveRay, .5f, 1.25f)) {

			randomizer = Random.Range(0f, 1f);

			if (randomizer <= 0.5f){
				
				transform.Rotate (0f, 90f, 0f);

			} else if(randomizer >0.5f && randomizer <= 1f){

				transform.Rotate (0f, -90f, 0f);

			}

		}

	}
}
