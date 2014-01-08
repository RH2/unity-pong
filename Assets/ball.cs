using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
	private float dir = -0.5f;
	// Use this for initialization
	void Start () {
		rigidbody.AddForce (new Vector3 (-10.0f, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {

			if (contact.otherCollider.gameObject.tag == "paddle") {
				Debug.Log ("asdfasdasf");
				if (rigidbody.position.x < 0) {
						this.dir = 10.0f;
				} else {
						this.dir = -10.0f;
				}
				rigidbody.AddForce (new Vector3 (this.dir, 0, 0));
			}
		}
	}
}
