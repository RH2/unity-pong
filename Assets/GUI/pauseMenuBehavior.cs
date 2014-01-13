using UnityEngine;
using System.Collections;

public class pauseMenuBehavior : MonoBehaviour {
	int activeItem = 1;
	bool menuVisible;
	bool menuVisibleLastFrame;
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

	int animationProgress=0;
	bool animaitonComplete=true;
	float keyboardCooldown = 0.18f;
	float keyboardCurrentCooldown;


	void Start () {resetkeyboardcooldown ();}
	void Update () {
		Debug.Log (activeItem);
		keyboardCurrentCooldown = keyboardCurrentCooldown - Time.deltaTime;
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
		if (menuVisible) {
			if (keyboardCurrentCooldown < 0f) {keyboardOffset ();}
			activeItem = checkMouseOver(activeItem);
			updateMenu ();
			if (keyboardCurrentCooldown < 0f && (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyUp (KeyCode.Return) || Input.GetMouseButtonUp (0))) {
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
		} else if (resumeToggleObject.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 2;
		} else if (returnToggleObject.GetComponent<guiToggle> ().getMouseOver ()) {
			active = 3;
		} else {active = current;}
		
		return active;
	}
	void keyboardOffset(){	
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			//todo play sound up
			activeItem--;
			if(activeItem<1){activeItem=3;}
			resetkeyboardcooldown();
		}
		if ( Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S) ){
			//todo play sound down
			activeItem++;
			if(activeItem>3){activeItem=1;}
			resetkeyboardcooldown();
		}
	}
	void resetkeyboardcooldown(){keyboardCurrentCooldown = keyboardCooldown;}
	
	void reveal(){

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
