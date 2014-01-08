using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("left")) {
			this.transform.position = new Vector3(
				this.transform.position.x,
				this.transform.position.y,
				this.transform.position.z+ 0.1f
				);
		}

		if (Input.GetKey("right")) {
			this.transform.position = new Vector3(
				this.transform.position.x,
				this.transform.position.y,
				this.transform.position.z - 0.1f
				);
		}
	}
}
