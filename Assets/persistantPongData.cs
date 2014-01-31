using UnityEngine;
using System.Collections;

public class persistantPongData : MonoBehaviour {
	 static int playerOneScore = 0;
	 static int playerTwoScore = 0;
	 static int playerTwoType = 3;
	 static int winner = 1;
	 static float difficulty = 0.008f;

	
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

	//there can only be one!!!
	//private static bool created =false;
	

	void Awake(){}
	void Start () {
		//if (!created) {created=true;}else{Destroy(gameObject);}
	}
	void Update () {}
	void checkFirst(bool a){
		if (a==false){
			Destroy(gameObject);
		}
	}
}