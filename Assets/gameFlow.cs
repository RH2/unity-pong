using UnityEngine;
using System.Collections;

public class gameFlow : MonoBehaviour {
	//////////////////
	/// MOVING PARTS
	////////////////// 
	GameObject DATA;
	[SerializeField] GameObject paddle1;
	[SerializeField] GameObject paddle2;//player or computer bool?
	[SerializeField] GameObject ball;
	//////////////////
	/// DETECTORS
	////////////////// 
	[SerializeField] GameObject scorezone1;
	[SerializeField] GameObject scorezone2;
	[SerializeField] GameObject foulballdetector;
	[SerializeField] GameObject foulballdetector2;
	int player1score=0;
	int player2score=0;
	float scoreCooldown = 0.2f;
	float scoreCooldownCurrent;
	//////////////////
	/// USER INTERFACE
	////////////////// 
	[SerializeField] GameObject player1scoredisplay;
	[SerializeField] GameObject player2scoredisplay;
	[SerializeField] GameObject pausemenu;
	bool gamepaused = false;
	[SerializeField] AudioClip ballResetSound;


	void reset_scoreCooldownCurrent (){scoreCooldownCurrent = scoreCooldown;}
	public void setgamepause(bool a){gamepaused = a;}
	// Use this for initialization
	void Start () {
		DATA = GameObject.Find("A_DATA");
		DATA.GetComponent<persistantPongData> ().setPlayerOneScore(0);
		DATA.GetComponent<persistantPongData> ().setPlayerTwoScore(0);
		paddle2.GetComponent<Paddle> ().setPaddleType (DATA.GetComponent<persistantPongData> ().getPlayerTwoType());
		paddle2.GetComponent<Paddle> ().setDifficulty (DATA.GetComponent<persistantPongData> ().getDifficulty());
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
		scoreCooldownCurrent = scoreCooldownCurrent - Time.deltaTime;
		if (Input.GetKeyUp (KeyCode.P)) {
			pause();
		}
		bool scoreevent1 = scorezone1.GetComponent<scoreZone>().getEvent();
		if (scoreCooldownCurrent < 0) {
			if (scoreevent1) {
					reset_scoreCooldownCurrent ();
					serve2 ();
					player1score++;
					DATA.GetComponent<persistantPongData> ().setPlayerOneScore(player1score);
					player1scoredisplay.GetComponent<guiNumberController> ().inputNumber (player1score);
					if(player1score>3){
						DATA.GetComponent<persistantPongData>().setWinner(1);//1=player;2=player2;3=computer;
						Application.LoadLevel ("end");
					}
			}
			bool scoreevent2 = scorezone2.GetComponent<scoreZone> ().getEvent ();
			if (scoreevent2) {
					reset_scoreCooldownCurrent ();
					serve1 ();
					player2score++;
					DATA.GetComponent<persistantPongData> ().setPlayerTwoScore(player2score);
					player2scoredisplay.GetComponent<guiNumberController> ().inputNumber (player2score);
					if(player2score>3){
							switch (DATA.GetComponent<persistantPongData>().getPlayerTwoType()){
								case(2):
									DATA.GetComponent<persistantPongData>().setWinner(2);//1=player;2=player2;3=computer;
									break;
								case(3):
									DATA.GetComponent<persistantPongData>().setWinner(3);//1=player;2=player2;3=computer;
									break;
							}
						Application.LoadLevel ("end");
					}
			}
		}
		if (foulballdetector.GetComponent<scoreZone> ().getEvent () || foulballdetector2.GetComponent<scoreZone> ().getEvent ()) {randomServeCenter();}

		//states:   foul ball, start player 1, start player 2
	}

	void randomServe(){
		float flip;
		flip = Random.value;
		if (flip <= 0.5) {serve1 ();} else {serve2();}
	} 
	void randomServeCenter(){
		float flip;
		flip = Random.value;
		if (flip <= 5) {serve1 ();} else {serve2();}
		}
	void serve1(){
		AudioSource.PlayClipAtPoint(ballResetSound,new Vector3(-12f, 25f, 0f),1f);
		paddle1.GetComponent<Paddle> ().setActiveServer (true,true);


	}
	void serve2(){
		AudioSource.PlayClipAtPoint(ballResetSound,new Vector3(12f, 25f, 0f),1f);
		paddle2.GetComponent<Paddle> ().setActiveServer (true,false);

	}
}