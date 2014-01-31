using UnityEngine;
using System.Collections;
public class ball : MonoBehaviour {
	float speed=25f;
	private float dir = -0.5f;
	[SerializeField] AudioClip hitBoundry;
	[SerializeField] AudioClip hitPaddle;
	[SerializeField] AudioClip scoreA;
	[SerializeField] AudioClip scoreB;

	[SerializeField] GameObject particleA;
	float mass=1f;
	void Start () {
		float mass = rigidbody.mass;
		//a = (AudioClip)Resources.Load("Sounds/ball_bounce");
		//b = (AudioClip)Resources.Load("Sounds/ball_bounce2");
		//rigidbody.AddForce (new Vector3 (-10.0f, 0, 0));
	}
	void FixedUpdate(){
		pushIntoGameAreaZ ();
	}
	void Update () {

		if (Mathf.Abs(rigidbody.velocity.x) < speed && this.transform.parent.tag != "paddle" ) {
			rigidbody.AddForce(Vector3.right*0.05f);
			//rigidbody.AddForce(  Vector3.forward *20*mass*(2*Mathf.Abs (rigidbody.velocity.z)));
			//rigidbody.velocity = rigidbody.velocity.normalized * speed;
		}
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
	void pushIntoGameAreaZ(){
		//float speedZ = rigidbody.velocity.z;
		float mass = rigidbody.mass;

		if (this.transform.position.z > 5.25f) {//if the ball is above the top bountary, it creates a negative vector and applies it to the z as a force
			rigidbody.AddForce( Vector3.forward * 208*mass*(-2*Mathf.Abs(rigidbody.velocity.z)));
		}else if (this.transform.position.z < -5.25f) {
			rigidbody.AddForce(  Vector3.forward *208*mass*(2*Mathf.Abs (rigidbody.velocity.z)));
		} 
	}

	void particleAdd(Transform a){
		GameObject newSplash = Instantiate (particleA, a.position, a.rotation) as GameObject;
	}
}