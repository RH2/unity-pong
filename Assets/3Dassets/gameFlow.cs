using UnityEngine;
using System.Collections;

public class gameFlow : MonoBehaviour {
	//////////////////
	/// MOVING PARTS
	////////////////// 
	[SerializeField] GameObject paddle1;
	[SerializeField] GameObject paddle2;//player or computer bool?
	[SerializeField] GameObject ball;
	//////////////////
	/// DETECTORS
	////////////////// 
	[SerializeField] GameObject scorezone1;
	[SerializeField] GameObject scorezone2;
	[SerializeField] GameObject foulballdetector;
	int player1score=0;
	int player2score=0;
	//////////////////
	/// USER INTERFACE
	////////////////// 
	[SerializeField] GameObject player1scoredisplay;
	[SerializeField] GameObject player2scoredisplay;
	[SerializeField] GameObject pausemenu;




	// Use this for initialization
	void Start () {
		//randomServeCenter ();
		//update score objects
		//randomly choose which player does the first serve

	
	}
	
	// Update is called once per frame
	void Update () {
		bool scoreevent1 = scorezone1.GetComponent<scoreZone>().getEvent();
		if (scoreevent1) {
			player1score++;
			Debug.Log("player1score: "+player1score);
			//update score2 object
			serve2();//player 2 serves
			//Application.LoadLevel (Application.loadedLevelName);

		}
		bool scoreevent2 = scorezone2.GetComponent<scoreZone>().getEvent();
		if (scoreevent2) {
			player2score++;
			Debug.Log("player2score: "+player2score);
			serve1();//update score1 object
			//player 1 serves

		}
		bool foul = foulballdetector.GetComponent<scoreZone>().getEvent();
		if (foul) {
			randomServeCenter();
			Debug.Log("foul");
			//randomServeCenter;
			}

		//states:   foul ball, start player 1, start player 2
	}

	void randomServe(){
		float flip;
		flip = Random.value;
		if (flip <= 5) {serve1 ();} else {serve2();}
	} 
	void randomServeCenter(){
		float flip;
		flip = Random.value;
		if (flip <= 5) {serve1 ();} else {serve2();}
		}
	void serve1(){
		//from paddle1 until user hits hotkey, then it adds paddles velocity + horizonatal
		ball.transform.position = paddle1.transform.position;
		ball.transform.position = new Vector3(ball.transform.position.x + 2.0f, 0.5f, 0.0f);
		ball.rigidbody.velocity = Vector3.zero;
		ball.rigidbody.angularVelocity = Vector3.zero;
		//ball.transform.position.parent = paddle1.transform;
	}
	void serve2(){
		ball.transform.position = paddle2.transform.position;
	}
	void pauseGame(){
		//set pause menu to visible
		//resume
		//restart
		//main menu
		//exit	
	}

}
