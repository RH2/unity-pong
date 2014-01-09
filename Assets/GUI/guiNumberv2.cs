using UnityEngine;
using System.Collections;

public class guiNumberv2 : MonoBehaviour {
	int inputNumber;
	bool hidden=false;
	[SerializeField] GameObject asterisk;
	[SerializeField] GameObject num0;
	[SerializeField] GameObject num1;
	[SerializeField] GameObject num2;
	[SerializeField] GameObject num3;
	[SerializeField] GameObject num4;
	[SerializeField] GameObject num5;
	[SerializeField] GameObject num6;
	[SerializeField] GameObject num7;
	[SerializeField] GameObject num8;
	[SerializeField] GameObject num9;
	void Start () {
		asterisk.renderer.enabled = false;
		num0.renderer.enabled = false;
		num1.renderer.enabled = false;
		num2.renderer.enabled = false;
		num3.renderer.enabled = false;
		num4.renderer.enabled = false;
		num5.renderer.enabled = false;
		num6.renderer.enabled = false;
		num7.renderer.enabled = false;
		num8.renderer.enabled = false;
		num9.renderer.enabled = false;
	}
	void Update () {
		if (!hidden) {
			setVisibility (inputNumber);
		}
		
	}
	public void setHidden(bool a){hidden = a;} 
	public void setNumber(int a){inputNumber = a;} 
	public int getNumber(){return inputNumber;}
	
	void setVisibility(int a){
		asterisk.renderer.enabled = false;
		num0.renderer.enabled = false;
		num1.renderer.enabled = false;
		num2.renderer.enabled = false;
		num3.renderer.enabled = false;
		num4.renderer.enabled = false;
		num5.renderer.enabled = false;
		num6.renderer.enabled = false;
		num7.renderer.enabled = false;
		num8.renderer.enabled = false;
		num9.renderer.enabled = false;
		if (a == null) {
			asterisk.renderer.enabled = true;
		}
		if (a != null){
			switch (a+1) {
			case(1):
				num0.renderer.enabled = true;
				break;
			case(2):
				num1.renderer.enabled = true;
				break;
			case(3):
				num2.renderer.enabled = true;
				break;
			case(4):
				num3.renderer.enabled = true;
				break;
			case(5):
				num4.renderer.enabled = true;
				break;
			case(6):
				num5.renderer.enabled = true;
				break;
			case(7):
				num6.renderer.enabled = true;
				break;
			case(8):
				num7.renderer.enabled = true;
				break;
			case(9):
				num8.renderer.enabled = true;
				break;
			case(10):
				num9.renderer.enabled = true;
				break;
			}
		}
	}
}