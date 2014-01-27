using UnityEngine;
using System.Collections;

public class cameraSoftLerp : MonoBehaviour {
	[SerializeField] GameObject ball;
	float lerpSpeed = 0.008f;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(lerpSpeed*(ball.rigidbody.position.x - this.transform.position.x), 0f, lerpSpeed*(ball.rigidbody.position.z - this.transform.position.z));
	}
}
