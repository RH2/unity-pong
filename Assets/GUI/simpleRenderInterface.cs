using UnityEngine;
using System.Collections;

public class simpleRenderInterface : MonoBehaviour {
	bool visible = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (visible) {this.renderer.enabled=true;}else{this.renderer.enabled=false;}
		
	}
	public void setvisibility(bool a){
		visible = a;
	}
}
