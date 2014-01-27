using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	[SerializeField] GameObject ball;
	public Vector3 velocity;
	[SerializeField] int paddletype =1; //1 equals player, 2 equals network, 3 equals computer control
	float difficulty=0.01f;
	bool paddleActiveServer = false; //if true, this paddle serves
	float distance= 1f;
	void Start () {}
	void Update () {
		switch (paddletype) {
			case(1)://is player1
				if (Input.GetKey("left")) {
					this.velocity += new Vector3(0.0f, 0.0f, 10.0f);
				}			
				if (Input.GetKey("right")) {
					this.velocity -= new Vector3(0.0f, 0.0f, 10.0f);
				}
				if (Input.GetKeyUp("space")) {
					//GameObject [] balls = GameObject.FindGameObjectsWithTag("ball");
					//foreach (GameObject b in balls) {
					if (ball.transform.parent == this.transform) {
						ball.transform.parent = null;
						ball.rigidbody.velocity = velocity + new Vector3((transform.position.x < 0) ? 50.0f : -50.0f, 0.0f, 0.0f);
					}
				}
				
				this.transform.position += velocity * Time.deltaTime;
				velocity.Scale(new Vector3(0.0f, 0.0f, 0.8f));
				break;
			case(2)://is player via network
				break;		
			case(3)://is computer control
			//Debug.Log("made it here"+"   ball.z= "+ball.transform.position.z+"    this.z* "+this.transform.position.z);
			this.transform.position += new Vector3(0f, 0f, difficulty*(ball.rigidbody.position.z - this.transform.position.z));
			/*		if (ball.transform.position.z<transform.position.z){
						//do something
					}
					else{
						//do something else
					}*/
			break;
		}
	}
	public void ballAttach(){ball.transform.parent = this.transform;}
	public void setActiveServer(bool a){paddleActiveServer = a;}
	public void setPaddleType(int a){paddletype = a;}
	public void setDifficulty(float a){difficulty = a;}
}
