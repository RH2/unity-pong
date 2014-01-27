using UnityEngine;
using System.Collections;

public class scoreZone : MonoBehaviour {
	public bool interaction = false;
	void Start () {}
	void Update () {}
	void OnTriggerEnter(Collider other){
		if (other.tag == "ball"){interaction = true;}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "ball"){interaction = false;}
	}
	public bool getEvent(){return interaction;}
}
