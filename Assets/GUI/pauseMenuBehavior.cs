using UnityEngine;
using System.Collections;

public class pauseMenuBehavior : MonoBehaviour {
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


	int animationProgress=0;
	bool animaitonComplete=true;


	void Start () {}
	void process(){
		//if (animationProgress == 0 && (menuVisible == menuVisibleLastFrame)) {
		if (menuVisible != menuVisibleLastFrame) {animationProgress=0;animaitonComplete=false;}
		animationProgress = animateBottomCorners (animationProgress, menuVisible);
	}
	void Update () {
		//if visible
		if (menuVisible) {
			//extend

			//if extended show menu
				reveal ();
		}
		//if hidden
		if (!menuVisible) {
			//hide menu
				hide ();
			//retract
		}
				
				
		//once fully visible
			//track active element via index


	}
	void reveal(){
		redArcUL.renderer.enabled = true;
		redArcUR.renderer.enabled = true;
		redArcBL.renderer.enabled = true;
		redArcBR.renderer.enabled = true;
		pauseToggleObject.GetComponent<guiToggle> ().setAllVisible(true);
		resumeToggleObject.GetComponent<guiToggle> ().setAllVisible(true);
		returnToggleObject.GetComponent<guiToggle> ().setAllVisible(true);
		//animate redArcbr(y)&redArcbl(x) for loop*
		//after animation reveal 
	}
	void hide(){
		redArcUL.renderer.enabled = false;
		redArcUR.renderer.enabled = false;
		redArcBL.renderer.enabled = false;
		redArcBR.renderer.enabled = false;
		pauseToggleObject.GetComponent<guiToggle> ().setAllVisible(false);
		resumeToggleObject.GetComponent<guiToggle> ().setAllVisible(false);
		returnToggleObject.GetComponent<guiToggle> ().setAllVisible(false);
		//animate redArcbr(y)&redArcbl(x) for loop*
		//after animation reveal 
	}
	int animateBottomCorners(int progress,bool direction){
		//direction if true, move down //if false, move up
		float distance = 0.1f;//change distance per tic
		if (progress < 0 && direction) {
		//down
			redArcBL.transform.Translate (distance, 0f, 0f);
			redArcBR.transform.Translate (0f, distance, 0f);
			return (progress++);
		} else if (progress > -10 && !direction) {
		//up
			redArcBL.transform.Translate (-distance, 0f, 0f);
			redArcBR.transform.Translate (0f, -distance, 0f);
			return (progress--);
		} else {return (progress++);}
	}
	public void setMenuvisibility(bool inputa){menuVisible = inputa;}
}
