using UnityEngine;
using System.Collections;

public class DestroyParticleObject : MonoBehaviour {
	void Start () {Destroy(this.gameObject, 5.0F);}
	void Update () {}
}
