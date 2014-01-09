using UnityEngine;
using System.Collections;

public class guiNumberController : MonoBehaviour {
	[SerializeField] GameObject guiNum;
	[SerializeField] float spacing = 0.000006f;
	GameObject	newnum_Ones;
	GameObject	newnum_Tens;
	GameObject	newnum_Hundreds;
	int number;
	void Start () {
		//+Vector3(spacing*1f,0f,0f)
		newnum_Ones = (GameObject) Instantiate(guiNum, transform.position, transform.rotation);
		newnum_Ones.transform.parent = this.transform;
		//newnum_Ones.transform.parent = this.gameObject;
		newnum_Tens = (GameObject) Instantiate(guiNum, transform.position, transform.rotation);
		newnum_Tens.transform.Translate = new Vector3 (0.1f, 0f, 0f);
		//newnum_Ones.transform.parent = this.transform;

		//newnum_Tens.transform.parent = this.gameObject;
		newnum_Hundreds = (GameObject) Instantiate(guiNum, transform.position, transform.rotation);
		newnum_Tens.transform.Translate = new Vector3 (0.1f, 0f, 0f);
		//newnum_Ones.transform.parent = this.transform;
		//newnum_Hundreds.transform.parent = this.gameObject;
	}
	void Update () {
		Debug.Log (newnum_Ones.transform.position);
		newnum_Ones.GetComponent<guiNumberv2> ().setHidden(true);
		newnum_Tens.GetComponent<guiNumberv2> ().setHidden(true);
		newnum_Hundreds.GetComponent<guiNumberv2> ().setHidden(true);

		number = (int )Time.time;
		int a = number % 10;
		if (a >= 0) {
			newnum_Ones.GetComponent<guiNumberv2> ().setNumber(a);
			newnum_Ones.GetComponent<guiNumberv2> ().setHidden(false);
		}
		a = (number / 10) % 10;
		if (number>=10) {
			newnum_Tens.GetComponent<guiNumberv2> ().setNumber(a);
			newnum_Tens.GetComponent<guiNumberv2> ().setHidden(false);
		}
		a = (number / 100) % 10;
		if (number>=100) {
			newnum_Hundreds.GetComponent<guiNumberv2> ().setNumber(a);
			newnum_Hundreds.GetComponent<guiNumberv2> ().setHidden(false);
		}

	}
}
