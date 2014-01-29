﻿using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {
	int activeItem = 1;
	[SerializeField] GameObject DATA;
	[SerializeField] GameObject menu1;
	[SerializeField] GameObject menu2;
	[SerializeField] GameObject menu3;
	[SerializeField] GameObject menu4;
	[SerializeField] GameObject menu5;
	[SerializeField] GameObject menu6;
	[SerializeField] GameObject menu7;
	[SerializeField] GameObject menu8;


	float keyboardCooldown = 0.18f;
	float keyboardCurrentCooldown;


	int thisframe=1;
	int lastchange=1;





	//sfx/////////////////////////////
	[SerializeField] AudioClip introSound;
	[SerializeField] AudioClip pauseMenuUp;
	[SerializeField] AudioClip pauseMenuDown;
	[SerializeField] AudioClip execute;
	
	void soundfxIntro(){AudioSource.PlayClipAtPoint(introSound,new Vector3(0f, 0f, 0f),1f);}
	void soundfxUp(){AudioSource.PlayClipAtPoint(pauseMenuUp,new Vector3(0f, 0f, 0f),1f);}
	void soundfxDown(){AudioSource.PlayClipAtPoint(pauseMenuDown,new Vector3(0f, 0f, 0f),1f);}
	void soundfxExecute(){AudioSource.PlayClipAtPoint(execute,new Vector3(0f, 0f, 0f),1f);}


	//mechanics//////////////////////
	void OnLevelWasLoaded(){Start();}
	void Start () {
		Time.timeScale = 1F;
		soundfxIntro ();
		activeItem = 1;
		menu1.GetComponent<guiToggle> ().setAllVisible(true);
		menu2.GetComponent<guiToggle> ().setAllVisible(true);
		menu3.GetComponent<guiToggle> ().setAllVisible(true);
		menu4.GetComponent<guiToggle> ().setAllVisible(true);
		menu5.GetComponent<guiToggle> ().setAllVisible(true);
		menu6.GetComponent<guiToggle> ().setAllVisible(true);
		menu7.GetComponent<guiToggle> ().setAllVisible(true);
		menu8.GetComponent<guiToggle> ().setAllVisible(true);


		resetkeyboardcooldown ();

	}
	
	// Update is called once per frame
	void Update () {
		keyboardCurrentCooldown = keyboardCurrentCooldown - Time.deltaTime;
		if (keyboardCurrentCooldown < 0f) {keyboardOffset ();}
		activeItem = checkMouseOver(activeItem);
		updateMenu ();

		//check menu change to play appropriate sfx
		thisframe=activeItem;
		if(thisframe!=lastchange){
			if(thisframe<lastchange){soundfxDown();}
			if(thisframe>lastchange){soundfxUp();}
			lastchange=thisframe;
		}


		if (keyboardCurrentCooldown < 0f && (Input.GetKeyUp(KeyCode.Space)||Input.GetKeyUp(KeyCode.Return)|| Input.GetMouseButtonDown(0))) {executeChoice ();}
	}
	void executeChoice(){
			//play execute sound
				soundfxExecute();
			resetkeyboardcooldown();
			switch(activeItem){
			case(1):
				DATA.GetComponent<persistantPongData> ().setPlayerTwoType(3);//1 local //2 network //3 computer
				DATA.GetComponent<persistantPongData> ().setPlayerOneScore(0);
				DATA.GetComponent<persistantPongData> ().setPlayerTwoScore(0);
				Application.LoadLevel ("arena");
				break;
			case(2):
				
				break;
			case(3):
				
				break;
			case(4):
				
				break;
			case(5):
				
				break;
			case(6):
				Application.OpenURL("https://twitter.com/R_H_2");
				break;
			case(7):
				Application.OpenURL("http://twitter.com/tmpvar");
				break;
			case(8):
				Application.Quit();
				break;
			}

	}
	void updateMenu(){
		if (activeItem == 1) {
			menu1.GetComponent<guiToggle> ().setToggle(true);
		}else{menu1.GetComponent<guiToggle> ().setToggle(false);}
		if (activeItem == 2) {
			menu2.GetComponent<guiToggle> ().setToggle(true);
		}else{menu2.GetComponent<guiToggle> ().setToggle(false);}
		if (activeItem == 3) {
			menu3.GetComponent<guiToggle> ().setToggle(true);
		}else{menu3.GetComponent<guiToggle> ().setToggle(false);}
		if (activeItem == 4) {
			menu4.GetComponent<guiToggle> ().setToggle(true);
		}else{menu4.GetComponent<guiToggle> ().setToggle(false);}
		if (activeItem == 5) {
			menu5.GetComponent<guiToggle> ().setToggle(true);
		}else{menu5.GetComponent<guiToggle> ().setToggle(false);}
		if (activeItem == 6) {
			menu6.GetComponent<guiToggle> ().setToggle(true);
		}else{menu6.GetComponent<guiToggle> ().setToggle(false);}
		if (activeItem == 7) {
			menu7.GetComponent<guiToggle> ().setToggle(true);
		}else{menu7.GetComponent<guiToggle> ().setToggle(false);}
		if (activeItem == 8) {
			menu8.GetComponent<guiToggle> ().setToggle(true);
		}else{menu8.GetComponent<guiToggle> ().setToggle(false);}
	}
	int checkMouseOver(int current){
		int active = 1;
		if (menu1.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 1;
		} else if (menu2.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 2;
		} else if (menu3.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 3;
		} else if (menu4.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 4;
		} else if (menu5.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 5;
		} else if (menu6.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 6;
		} else if (menu7.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 7;
		} else if (menu8.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 8;
		} else {active = current;}

		return active;
	}
	void keyboardOffset(){	
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			//todo play sound up
			activeItem--;
			if(activeItem<1){activeItem=8;}
			resetkeyboardcooldown();
		}
		if ( Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S) ){
			//todo play sound down
			activeItem++;
			if(activeItem>8){activeItem=1;}
			resetkeyboardcooldown();
		}
	}
	void resetkeyboardcooldown(){keyboardCurrentCooldown = keyboardCooldown;}
}
