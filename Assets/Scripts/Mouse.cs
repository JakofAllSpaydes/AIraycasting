using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	Rigidbody rbody;

	public Transform cat;
	Vector3 directionToCat;

	public AudioClip[] arrayOfSounds; 
	public AudioSource myAudioSource;

	float Timer;
	public bool soundPlayed;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody> ();

	}

	void Update () {
		if (soundPlayed == true) {
			
			Timer += Time.deltaTime;

		}

		if (Timer >= 1) {

			soundPlayed = false;
			Timer = 0;

		}
	}

	// Update is called once per frame
	void FixedUpdate () {
	
		directionToCat = cat.position - transform.position;

		if (Vector3.Angle (transform.forward, directionToCat) < 180f) {

			Ray mouseRay = new Ray (transform.position, directionToCat);
			RaycastHit mouseRayHitInfo;

			Debug.DrawRay(transform.position, directionToCat, Color.green);
	

			if (Physics.Raycast(mouseRay, out mouseRayHitInfo, 7f)){

				if (mouseRayHitInfo.collider.tag == "Cat"){
					Debug.Log ("RUN FROM CAT");
					rbody.AddForce (-directionToCat.normalized * 2000f);
					if (soundPlayed == false) {
						myAudioSource.PlayOneShot (arrayOfSounds[0]);
						soundPlayed = true;
					}

				}

			}

		}

	}
}
