using UnityEngine;
using System.Collections;

public class endFlow : MonoBehaviour {
	GameObject DATA;
	[SerializeField] GameObject playerOneWins;
	[SerializeField] GameObject playerTwoWins;
	[SerializeField] GameObject computerWins;
	[SerializeField] GameObject returnToMenu;

	int endState=0;
	int playerOneFinalScore=000;
	int playerTwoFinalScore=000;
	[SerializeField] GameObject playerOneScore;
	[SerializeField] GameObject playerTwoScore;



	// Use this for initialization
	void Start () {
		DATA = GameObject.Find("A_DATA");
		endState = DATA.GetComponent<persistantPongData> ().getWinner();
		playerOneFinalScore = DATA.GetComponent<persistantPongData> ().getPlayerOneScore();
		playerTwoFinalScore = DATA.GetComponent<persistantPongData> ().getPlayerTwoScore();
		playerOneScore.GetComponent<guiNumberv2> ().setNumber (playerOneFinalScore);
		playerTwoScore.GetComponent<guiNumberv2> ().setNumber (playerTwoFinalScore);
		returnToMenu.GetComponent<guiToggle> ().setAllVisible(true);

		playerOneWins.renderer.enabled = false;
		playerTwoWins.renderer.enabled = false;
		computerWins.renderer.enabled = false;

		switch (endState) {
			case(1):
				playerOneWins.renderer.enabled = true;
				break;
			case(2):
				playerTwoWins.renderer.enabled = true;
				break;
			case(3):
				computerWins.renderer.enabled = true;
				break;

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Application.LoadLevel ("menu");
			Debug.Log("here");
		}
	
	}
}
