using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {
	int activeItem = 1;
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
	// Use this for initialization
	void Start () {
		keyboardCurrentCooldown = keyboardCooldown;
	}
	
	// Update is called once per frame
	void Update () {
		keyboardCurrentCooldown = keyboardCurrentCooldown -Time.deltaTime;
		if (keyboardCurrentCooldown > 0f) {keyboardOffset ();}
		activeItem = checkMouseOver(activeItem);
		updateMenu ();
		Debug.Log (activeItem);
		if (keyboardCurrentCooldown > 0f && (Input.GetKeyUp(KeyCode.Space)||Input.GetKeyUp(KeyCode.Return)|| Input.GetMouseButtonDown(0))) {executeChoice ();}
	}
	void executeChoice(){
		//if (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.Return)|| Input.GetMouseButtonDown(0))
		//if (Input.GetKeyUp(KeyCode.Space)||Input.GetKeyUp(KeyCode.Return)|| Input.GetMouseButtonDown(0)){
			//todo play execute sound
			Debug.Log("you clicked:  "+activeItem);
			keyboardCurrentCooldown = keyboardCooldown;
			switch(activeItem){
			case(1):
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
		}
		if ( Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S) ){
			//todo play sound down
			activeItem++;
			if(activeItem>8){activeItem=1;}
		}
		keyboardCurrentCooldown = keyboardCooldown;

	}
}
