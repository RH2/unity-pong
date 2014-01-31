using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {
	int activeItem = 1;
	GameObject DATA;
	[SerializeField] GameObject menu1;
	[SerializeField] GameObject menu2;
	[SerializeField] GameObject menu3;
	[SerializeField] GameObject menu4;


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
		DATA = GameObject.Find("A_DATA");
		Time.timeScale = 1F;
		soundfxIntro ();
		activeItem = 1;
		menu1.GetComponent<guiToggle> ().setAllVisible(true);
		menu2.GetComponent<guiToggle> ().setAllVisible(true);
		menu3.GetComponent<guiToggle> ().setAllVisible(true);
		menu4.GetComponent<guiToggle> ().setAllVisible(true);


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
				Application.OpenURL("https://twitter.com/R_H_2");				
				break;
			case(3):
				Application.OpenURL("http://twitter.com/tmpvar");
				break;
			case(4):
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
		} else {active = current;}

		return active;
	}
	void keyboardOffset(){	
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			//todo play sound up
			activeItem--;
			if(activeItem<1){activeItem=4;}
			resetkeyboardcooldown();
		}
		if ( Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S) ){
			//todo play sound down
			activeItem++;
			if(activeItem>4){activeItem=1;}
			resetkeyboardcooldown();
		}
	}
	void resetkeyboardcooldown(){keyboardCurrentCooldown = keyboardCooldown;}
}
