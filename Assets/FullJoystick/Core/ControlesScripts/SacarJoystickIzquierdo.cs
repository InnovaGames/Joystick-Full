using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacarJoystickIzquierdo : MonoBehaviour {

	public GameObject MyJoystickSaved;
	public GameObject MyJoystickNow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ToOut ();
	}
	public void ToOut (){
		if (MyJoystickNow == null) {
			MyJoystickNow = Instantiate (MyJoystickSaved, JoystickIzquierdoSpot.MiYo.transform.position, Quaternion.identity, JoystickIzquierdoSpot.MiYo.transform);
		}
	}
}