using UnityEngine;
using System.Collections;

public class PaddleAdditiveVisibility : MonoBehaviour {
	bool visible=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.enabled = visible;
	
	}
	public void setVisible(bool a){visible=a;}
}
