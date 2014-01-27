using UnityEngine;
using System.Collections;

public class endFlow : MonoBehaviour {
	[SerializeField] GameObject DATA;
	[SerializeField] GameObject playerOneWins;
	[SerializeField] GameObject playerTwoWins;
	[SerializeField] GameObject computerWins;

	int endState=0;
	int playerOneFinalScore=000;
	int playerTwoFinalScore=000;
	[SerializeField] GameObject playerOneScore;
	[SerializeField] GameObject playerTwoScore;



	// Use this for initialization
	void Start () {
	//	endState = DATA.GetComponent<dataBlock> ().getState();
	//	playerOneFinalScore = DATA.GetComponent<dataBlock> ().getScoreA();
	//	playerTwoFinalScore = DATA.GetComponent<dataBlock> ().getScoreB();
		playerOneScore.GetComponent<guiNumberv2> ().setNumber (playerOneFinalScore);
		playerTwoScore.GetComponent<guiNumberv2> ().setNumber (playerTwoFinalScore);

		playerOneWins.renderer.enabled = false;
		playerTwoWins.renderer.enabled = false;
		computerWins.renderer.enabled = false;

		switch (endState) {
			case(1):
				playerOneWins.renderer.enabled = true;
				break;
			case(2):
				playerOneWins.renderer.enabled = true;
				break;
			case(3):
				playerOneWins.renderer.enabled = true;
				break;

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
