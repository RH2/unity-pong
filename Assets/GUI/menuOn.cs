using UnityEngine;
using System.Collections;

public class menuOn : MonoBehaviour {
	[SerializeField] GameObject newgame;
	[SerializeField] GameObject multi;
	[SerializeField] GameObject options;
	[SerializeField] GameObject net;
	[SerializeField] GameObject single;
	[SerializeField] GameObject rh2;
	[SerializeField] GameObject tmp;
	[SerializeField] GameObject exit;
	// Use this for initialization
	void Start () {
		newgame.GetComponent<guiToggle> ().setAllVisible(true);
		multi.GetComponent<guiToggle> ().setAllVisible(true);
		options.GetComponent<guiToggle> ().setAllVisible(true);
		net.GetComponent<guiToggle> ().setAllVisible(true);
		single.GetComponent<guiToggle> ().setAllVisible(true);
		rh2.GetComponent<guiToggle> ().setAllVisible(true);
		tmp.GetComponent<guiToggle> ().setAllVisible(true);
		exit.GetComponent<guiToggle> ().setAllVisible(true);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
