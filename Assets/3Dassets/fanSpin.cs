using UnityEngine;
using System.Collections;

public class fanSpin : MonoBehaviour {
	[SerializeField] float speed = 3f;

	// Use this for initialization
	public void setSpeed(float a){speed = a;}
	void Start () {	}
	// Update is called once per frame
	void Update () {
		float rotation = speed + (speed*Time.deltaTime);
		transform.Rotate(0f,0f,rotation);
	}
}
