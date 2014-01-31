using UnityEngine;
using System.Collections;

public class cameraSoftLerp : MonoBehaviour {
	[SerializeField] GameObject ball;
	float lerpSpeed = 0.008f;
	float concurrentCollisions;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		concurrentCollisions=Mathf.Clamp (concurrentCollisions,0f,0.95f);
		executeCameraShake ();
		this.transform.position += new Vector3(lerpSpeed*(ball.rigidbody.position.x/2f - this.transform.position.x), 0f, lerpSpeed*(ball.rigidbody.position.z/2f - this.transform.position.z));
	}
	public void increaseCameraShake(){
		concurrentCollisions=concurrentCollisions+1;

	}
	void executeCameraShake(){
		if (concurrentCollisions > 0) {
			this.transform.position += new Vector3(Random.value-0.5f,0f,Random.value-0.5f)*0.2f*concurrentCollisions;
		}
		Mathf.Floor(concurrentCollisions=concurrentCollisions-0.016f);
	}
}
