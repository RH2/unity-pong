using UnityEngine;
using System.Collections;

public class PaddleV2 : MonoBehaviour {
	[SerializeField] GameObject ball;
	[SerializeField] GameObject regular;
	[SerializeField] GameObject serving;
	[SerializeField] GameObject super;


	public Vector3 velocity;
	[SerializeField] int paddletype =1; //1 equals player, 2 equals network, 3 equals computer control
	float difficulty=0.01f;
	float distance= 1f;
	
	//computer serve random point & animaiton progress
	float serveThreshold = 0f;
	bool paddleActiveServer = false; //if true, this paddle serves
	bool PaddleMoveComplete=true;	//if true, this paddle can begin animation loop
	Vector3 computerServePosition;  //point generated for new serve position
	Vector3 paddleBeginServePosition;
	float serveProgress=0;
	
	
	
	void Start () {
		regular.GetComponent<PaddleAdditiveVisibility> ().setVisible(true);
	}
	void Update () {
		adjustPaddleAppearance ();
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
					paddleActiveServer=false;
				}
			}
			
			this.transform.position += velocity * Time.deltaTime;
			this.velocity.Scale(new Vector3(0.0f, 0.0f, 0.8f));
			
			if (this.transform.position.z > 3f) {
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 3f);
				this.velocity = new Vector3(0, 0, 0);
			} else if (this.transform.position.z < -3f) {
				this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -3f);
				this.velocity = new Vector3(0, 0, 0);
			}
			
			break;
		case(2)://is player via network
			break;
		case(3)://is computer control
			
			//available variables: 	///paddleActiveServer///PaddleMoveComplete///Vector3 computerServePosition;
			//serve?
			if (paddleActiveServer== true && PaddleMoveComplete==true) {
				paddleBeginServePosition= this.transform.position;
				ball.transform.parent = this.transform;							//ball is now child of paddle
				//computerServePosition = new Vector3(0f,0f,Random.Range(-5f,5f));	//new point/position generated	//5 - -5  serve range
				if(this.transform.position.z<0f){computerServePosition=new Vector3(this.transform.position.x,this.transform.position.y,2.739f);} else{computerServePosition=new Vector3(this.transform.position.x,this.transform.position.y,-2.739f);}
				serveThreshold = Random.Range(0.5f,1f);
				PaddleMoveComplete=false;										//animation loop will now be called in each update
				break;
			}
			if(PaddleMoveComplete==false){ serveProgress=AnimatePaddleToPoint(serveProgress); break;}
			this.transform.position += new Vector3(0f, 0f, difficulty*(ball.rigidbody.position.z - this.transform.position.z));
			//spin option?
			break;
		}
	}
	float AnimatePaddleToPoint(float a){
		this.transform.position =Vector3.Lerp (paddleBeginServePosition, computerServePosition, a);
		a=a+(100*difficulty*Time.deltaTime);
		//this.transform.position = Vector3.Lerp(this.transform.position,computerServePosition,Mathf.Clamp(difficulty*5f,0f,1f));
		//this.transform.position += new Vector3(0f, 0f, difficulty*(computerServePosition.z - this.transform.position.z));
		//distance check to set paddleMovecomplete to true & launch ball.
		if (a > serveThreshold) {
			a=0;
			PaddleMoveComplete=true;
			paddleActiveServer=false;
			ball.transform.parent = null;
			ball.rigidbody.velocity = velocity + new Vector3((transform.position.x < 0) ? 50.0f : -50.0f, 0f, computerServePosition.z-paddleBeginServePosition.z*2f);
		}
		return a;
	}
	public void ballAttach(){ball.transform.parent = this.transform;}
	
	public void setActiveServer(bool a, bool b){//b true =player 1, b false = player 2
		paddleActiveServer = a;
		ball.rigidbody.velocity = Vector3.zero;
		ball.rigidbody.angularVelocity = Vector3.zero;
		if (b) {
			ball.transform.position = new Vector3(this.transform.position.x + 3f, 0.5f, this.transform.position.z);//left side
		} else if (!b) {
			ball.transform.position = new Vector3(this.transform.position.x - 2f, 0.5f, this.transform.position.z);//right side
		}
		ball.transform.parent = this.transform;
	}
	void adjustPaddleAppearance(){
		if (paddleActiveServer==true) {
			regular.GetComponent<PaddleAdditiveVisibility> ().setVisible(false);
			serving.GetComponent<PaddleAdditiveVisibility> ().setVisible(true);

		} else if (paddleActiveServer==false) {
			regular.GetComponent<PaddleAdditiveVisibility> ().setVisible(true);
			serving.GetComponent<PaddleAdditiveVisibility> ().setVisible(false);

		}
	}
	public void setPaddleType(int a){paddletype = a;}
	public void setDifficulty(float a){difficulty = a;}
}
