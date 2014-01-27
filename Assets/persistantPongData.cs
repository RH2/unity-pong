using UnityEngine;
using System.Collections;

public class persistantPongData : MonoBehaviour {
	int playerOneScore = 0;
	int playerTwoScore = 0;
	int playerTwoType = 3;
	int winner = 1;
	float difficulty = 0.01f;

	
	//setters
	public void setPlayerOneScore(int a){playerOneScore = a;}
	public void setPlayerTwoScore(int a){playerTwoScore = a;}
	public void setPlayerTwoType(int a) {playerTwoType =  a;}
	public void setDifficulty(int a){difficulty = a;}
	public void setWinner(int a){winner = a;}

	//getters
	public int getPlayerOneScore(){return(playerOneScore);}
	public int getPlayerTwoScore(){return(playerTwoScore);}
	public int getPlayerTwoType() {return(playerTwoType);}
	public float getDifficulty(){return(difficulty);}
	public int getWinner(){return(winner);}

	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	void Update () {	
	}
}
