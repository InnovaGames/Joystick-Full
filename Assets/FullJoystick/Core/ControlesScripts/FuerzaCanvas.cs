using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuerzaCanvas : MonoBehaviour {

	public Vector3 ApplyLocalForce;
	public GameObject MyFather;
	public Rigidbody Rb;

	// Use this for initialization
	void Start () {
		ReloadMyFather ();
		ReloadRb ();
	}
	
	// Update is called once per frame
	void Update () {
		//ApplyRb ();
	}
	//public void OnFunctions

	public void ApplyRb (){
		if (Rb != null) {
			Rb.AddRelativeForce (ApplyLocalForce);
		}
	}

	public void ReloadRb (){
		if (Rb == null) {
			if (MyFather != null) {
				if (MyFather.GetComponent<Rigidbody> () != null) {
					Rb = MyFather.GetComponent<Rigidbody> ();
				}
			}
		}
	}
	public void ReloadMyFather (){
		if (MyFather == null) {
			if (PlayerStatico.Player1 != null) {
				MyFather = PlayerStatico.Player1.gameObject;
			}
		}
	}
}