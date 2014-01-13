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
	bool gamepaused = false;




	// Use this for initialization
	public void setgamepause(bool a){gamepaused = a;}
	void Start () {
		//randomServeCenter ();
		//update score objects
		//randomly choose which player does the first serve

	
	}
	
	// Update is called once per frame
	public void pause (){
		if (gamepaused) {
			gamepaused = false;
			Time.timeScale = 1F;
		} else {
			gamepaused = true;
			Time.timeScale = 0F;
		}
		pausemenu.GetComponent<pauseMenuBehavior> ().setMenuvisibility(gamepaused);
	}
	void Update () {
		if (Input.GetKeyUp (KeyCode.P)) {
			pause();
		}
		bool scoreevent1 = scorezone1.GetComponent<scoreZone>().getEvent();
		if (scoreevent1) {
			serve2();
			player1score++;
			Debug.Log("player1score: "+player1score);
			player1scoredisplay.GetComponent<guiNumberController> ().inputNumber(player1score);
			//Application.LoadLevel (Application.loadedLevelName);

		}
		bool scoreevent2 = scorezone2.GetComponent<scoreZone>().getEvent();
		if (scoreevent2) {
			serve1();
			player2score++;
			Debug.Log("player2score: "+player2score);
			player2scoredisplay.GetComponent<guiNumberController> ().inputNumber(player2score);


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
		ball.transform.position = new Vector3(paddle1.transform.position.x + 5, 0.5f, paddle1.transform.position.z);
		ball.rigidbody.velocity = Vector3.zero;
		ball.rigidbody.angularVelocity = Vector3.zero;
		ball.transform.parent = paddle1.transform;
	}
	void serve2(){
	}
}