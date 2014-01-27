using UnityEngine;
using System.Collections;

public class guiToggleALWAYS : MonoBehaviour {
	[SerializeField] GameObject Passive;
	bool mouseover = false;
	bool toggle = false;
	Ray ray;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			mouseover = false;
			renderer.enabled = false;
			Passive.renderer.enabled = true;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.collider.CompareTag (this.tag)) {
					mouseover = true;
					renderer.enabled = true;
					Passive.renderer.enabled = false;
				} 
			}
			if (toggle) {
				renderer.enabled = true;
				Passive.renderer.enabled = false;
			}
			renderer.enabled = false;
			Passive.renderer.enabled = false;

	}
	public bool getMouseOver(){return mouseover;}
	public void setToggle(bool a){toggle=a;}
	public bool getToggle(){return toggle;}
}