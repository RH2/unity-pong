using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public Vector3 velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("left")) {
			this.velocity += new Vector3(0.0f, 0.0f, 10.0f);
		}

		if (Input.GetKey("right")) {
			this.velocity -= new Vector3(0.0f, 0.0f, 10.0f);
		}

		if (Input.GetKeyUp("space")) {
			GameObject [] balls = GameObject.FindGameObjectsWithTag("ball");
			foreach (GameObject b in balls) {
				if (b.transform.parent == this.transform) {
					b.transform.parent = null;
					b.rigidbody.velocity = velocity + new Vector3((transform.position.x < 0) ? 50.0f : -50.0f, 0.0f, 0.0f);
				}
			}

		};

		this.transform.position += velocity * Time.deltaTime;
		velocity.Scale(new Vector3(0.0f, 0.0f, 0.8f));
	}
}
