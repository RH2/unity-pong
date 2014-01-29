using UnityEngine;
using System.Collections;
public class ball : MonoBehaviour {
	private float dir = -0.5f;
	[SerializeField] AudioClip hitBoundry;
	[SerializeField] AudioClip hitPaddle;
	[SerializeField] AudioClip scoreA;
	[SerializeField] AudioClip scoreB;

	[SerializeField] GameObject particleA;

	void Start () {
		//a = (AudioClip)Resources.Load("Sounds/ball_bounce");
		//b = (AudioClip)Resources.Load("Sounds/ball_bounce2");
		rigidbody.AddForce (new Vector3 (-10.0f, 0, 0));
	}
	void Update () {
	}
	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			if (contact.otherCollider.gameObject.tag == "resetBall"){
			}
			else if (contact.otherCollider.gameObject.tag == "boundry"){
				GameObject newSplash = Instantiate (particleA, contact.point, Quaternion.identity) as GameObject;
				//particleAdd(contact.otherCollider.gameObject.transform);
				audio.clip = hitBoundry;
				audio.Play();
				//AudioSource.PlayClipAtPoint(b,new Vector3(5, 1, 2),1.0f);
			}
			else if (contact.otherCollider.gameObject.tag == "paddle") {
				GameObject newSplash = Instantiate (particleA, contact.point, Quaternion.identity) as GameObject;
				audio.clip = hitPaddle;
				audio.Play();
				//AudioSource.PlayClipAtPoint(a,new Vector3(5, 1, 2),5.0f);
				if (rigidbody.position.x < 0) {
						this.dir = 5.0f;
				} else {
						this.dir = -5.0f;
				}
				rigidbody.AddForce (new Vector3 (this.dir, 0, 0));
			}
		}
	}

	void particleAdd(Transform a){
		GameObject newSplash = Instantiate (particleA, a.position, a.rotation) as GameObject;
	}
}