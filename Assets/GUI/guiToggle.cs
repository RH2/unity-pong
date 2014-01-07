using UnityEngine;
using System.Collections;

public class guiToggle : MonoBehaviour {
	//[SerializeField] GameObject Active;
	[SerializeField] GameObject Passive;
	bool toggle = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	
	}
	void OnMouseOver() {

	}
	void onMouseEnter(){Debug.Log("you are on me");}
	void onMouseExit(){Debug.Log ("agh!");}
	void onMouseOver(){Debug.Log("MONKEY");}
}
