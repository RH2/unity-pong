using UnityEngine;
using System.Collections;

public class guiNumberController : MonoBehaviour {
	[SerializeField] GameObject guiNum;
	float spacing = 1.1f;
	GameObject	newnum_Ones;
	GameObject	newnum_Tens;
	GameObject	newnum_Hundreds;
	int number;
	public void inputNumber(int a){number = a;}
	public int getNumber(){return number;}
	void Start () {
		//+Vector3(spacing*1f,0f,0f)
		newnum_Ones = (GameObject) Instantiate(guiNum, transform.position, transform.rotation);
		newnum_Ones.transform.localScale = this.transform.localScale;
		newnum_Ones.transform.parent = this.transform;
		//newnum_Ones.transform.parent = this.gameObject;
		newnum_Tens = (GameObject) Instantiate(guiNum, transform.position, transform.rotation);
		newnum_Tens.transform.Translate(spacing*1f, 0f, 0f);
		newnum_Tens.transform.localScale = this.transform.localScale;
		newnum_Tens.transform.parent = this.transform;

		//newnum_Tens.transform.parent = this.gameObject;
		newnum_Hundreds = (GameObject) Instantiate(guiNum, transform.position, transform.rotation);
		newnum_Hundreds.transform.Translate(spacing*2f, 0f, 0f);
		newnum_Hundreds.transform.localScale = this.transform.localScale;
		newnum_Hundreds.transform.parent = this.transform;
		//newnum_Hundreds.transform.parent = this.gameObject;
	}
	void Update () {
		//Debug.Log (newnum_Ones.transform.position);
		newnum_Ones.GetComponent<guiNumberv2> ().setHidden(true);
		newnum_Tens.GetComponent<guiNumberv2> ().setHidden(true);
		newnum_Hundreds.GetComponent<guiNumberv2> ().setHidden(true);
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
