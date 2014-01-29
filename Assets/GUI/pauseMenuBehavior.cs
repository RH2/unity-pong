using UnityEngine;
using System.Collections;

public class pauseMenuBehavior : MonoBehaviour {
	int activeItem = 1;
	bool menuVisible=false;
	bool menuOptionsAccess=false;
	[SerializeField] GameObject pauseToggleObject;
	[SerializeField] GameObject resumeToggleObject;
	[SerializeField] GameObject returnToggleObject;
	[SerializeField] GameObject redArcUR;
	[SerializeField] GameObject redArcUL;
	[SerializeField] GameObject redArcBR;
	[SerializeField] GameObject redArcBL;
	[SerializeField] GameObject orangeTop;
	[SerializeField] GameObject orangeBottom;
	[SerializeField] GameObject gamecontroller;
	[SerializeField] AudioClip pauseMenuUp;
	[SerializeField] AudioClip pauseMenuDown;

	int animationProgress=0;
	bool animaitonComplete=true;
	int keyboardCooldown = 10;
	int keyboardCurrentCooldown;

	void OnLevelWasLoaded(){Start();}
	void Start () {
		activeItem = 1;
		resetkeyboardcooldown ();
	}
	void Update () {
		keyboardCurrentCooldown = keyboardCurrentCooldown-1;
		//if visible
		if (menuVisible) {
			//extend
			animateMenu(menuVisible);
			//if extended show menu
				reveal ();
		}
		//if hidden
		if (!menuVisible) {
			//hide menu
				hide ();
			//retract
				animateMenu(menuVisible);
		}
		if (menuOptionsAccess) {
			Debug.Log(keyboardCurrentCooldown);
			if (keyboardCurrentCooldown < 0f) {
				Debug.Log ("has the keyboard done anything?");
				pauseKeyboardOffset ();
			}
			activeItem = checkMouseOver (activeItem);
			updateMenu ();
			if (keyboardCurrentCooldown < 0f && (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyUp (KeyCode.Return) || Input.GetMouseButtonUp (0))) {
				Debug.Log ("are we trying to execute?");
				executeChoice ();
			}
		}
	}
	void executeChoice(){
		//todo play execute sound
		resetkeyboardcooldown();
		switch(activeItem){
		case(1):
			gamecontroller.GetComponent<gameFlow>().pause();
			break;
		case(2):
			gamecontroller.GetComponent<gameFlow>().pause();
			break;
		case(3):
			Application.LoadLevel ("menu"); 
			break;
		}
		
	}
	void updateMenu(){
		if (activeItem == 1) {
			pauseToggleObject.GetComponent<guiToggle> ().setToggle(true);
		}else{pauseToggleObject.GetComponent<guiToggle> ().setToggle(false);}
		if (activeItem == 2) {
			resumeToggleObject.GetComponent<guiToggle> ().setToggle(true);
		}else{resumeToggleObject.GetComponent<guiToggle> ().setToggle(false);}
		if (activeItem == 3) {
			returnToggleObject.GetComponent<guiToggle> ().setToggle(true);
		}else{returnToggleObject.GetComponent<guiToggle> ().setToggle(false);}

	}
	int checkMouseOver(int current){
		int active = 1;
		if (pauseToggleObject.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 1;
			soundfxUP();
		} else if (resumeToggleObject.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 2;
			soundfxUP();
		} else if (returnToggleObject.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 3;
			soundfxUP();
		} else {active = current;}
		
		return active;
	}
	void pauseKeyboardOffset(){	
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
			//play sound up
				soundfxUP();
			activeItem--;
			if(activeItem<1){activeItem=3;}
			resetkeyboardcooldown();
		}
		if ( Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S) ){
			// play sound down
				soundfxDown();
			activeItem++;
			if(activeItem>3){activeItem=1;}
			resetkeyboardcooldown();
		}
	}
	void soundfxUP(){Time.timeScale = 1;AudioSource.PlayClipAtPoint(pauseMenuUp,new Vector3(0f, 22f, 0f),1f);Time.timeScale = 0;}
	void soundfxDown(){Time.timeScale = 1;AudioSource.PlayClipAtPoint(pauseMenuDown,new Vector3(0f, 22f, 0f),1f);Time.timeScale = 0;}
	void resetkeyboardcooldown(){keyboardCurrentCooldown = keyboardCooldown;}
	
	void reveal(){
		menuOptionsAccess = true;
		redArcUL.GetComponent<simpleRenderInterface> ().setvisibility(true);
		redArcUR.GetComponent<simpleRenderInterface> ().setvisibility(true);
		redArcBL.GetComponent<simpleRenderInterface> ().setvisibility(true);
		redArcBR.GetComponent<simpleRenderInterface> ().setvisibility(true);
		orangeTop.GetComponent<simpleRenderInterface> ().setvisibility(true);
		orangeBottom.GetComponent<simpleRenderInterface> ().setvisibility(true);

		pauseToggleObject.GetComponent<guiToggle> ().setAllVisible(true);
		resumeToggleObject.GetComponent<guiToggle> ().setAllVisible(true);
		returnToggleObject.GetComponent<guiToggle> ().setAllVisible(true);
		//animate redArcbr(y)&redArcbl(x) for loop*
		//after animation reveal 
	}
	void hide(){
		menuOptionsAccess = false;
		orangeTop.GetComponent<simpleRenderInterface> ().setvisibility(false);
		orangeBottom.GetComponent<simpleRenderInterface> ().setvisibility(false);

		pauseToggleObject.GetComponent<guiToggle> ().setAllVisible(false);
		resumeToggleObject.GetComponent<guiToggle> ().setAllVisible(false);
		returnToggleObject.GetComponent<guiToggle> ().setAllVisible(false);
		//animate redArcbr(y)&redArcbl(x) for loop*
		//after animation reveal 
	}
	void animateMenu(bool down){
		//direction if true, move down //if false, move up
		float distance = 0.38f;//change distance per tic
		if (animationProgress < 10 && down) {
		//down
			redArcBL.transform.Translate (distance, 0f, 0f);
			redArcBR.transform.Translate (0f, distance, 0f);
			orangeBottom.transform.Translate (0f, -distance, 0f);
			animationProgress++;
		} else if (animationProgress > 0 && !down) {
		//up
			redArcBL.transform.Translate (-distance, 0f, 0f);
			redArcBR.transform.Translate (0f, -distance, 0f);
			orangeBottom.transform.Translate (0f, distance, 0f);
			animationProgress--;
		}
		if (animationProgress < 1) {
			redArcUL.GetComponent<simpleRenderInterface> ().setvisibility(false);
			redArcUR.GetComponent<simpleRenderInterface> ().setvisibility(false);
			redArcBL.GetComponent<simpleRenderInterface> ().setvisibility(false);
			redArcBR.GetComponent<simpleRenderInterface> ().setvisibility(false);		
		}
	}
	public void setMenuvisibility(bool a){menuVisible = a;}
}
