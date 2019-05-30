using System.Collections;
using UnityEngine;

//HOMINISOFT TEAM INC. (hominidsoft@gmail.com)
//PROPIEDAD DE ROMEL LUCERO (eduardoften@gmail.com)
//PROPIEDAD DE ODALIS MONCADA
//
//VENEZUELA, MIRANDA DEL 27/01/2019
//
//ALL RIGHTS RESERVERD.
public class PlayerStatico : MonoBehaviour {

	public bool ForceToStatic;
	public static PlayerStatico Player1;
	public PlayerStatico SeePlayer1;
	public MiCamara MyCamera;
	public MiCamara2 Mycamera2;

	// Use this for initialization
	void Start () {
		RecargaNodoPlayer ();
		DefinirPlayer ();
		ReloadCam ();
		ReloadCam2 ();
	}
	void Update () {
		RecargaNodoPlayer ();
		DefinirPlayer ();
		ReloadCam ();
		ReloadCam2 ();
		ForceOn ();

	}
	public void ForceOn (){
		MyCamera.ForceToOut = true;
		Mycamera2.ForceToOut = true;
	}


	public void ReloadCam (){
		if (MyCamera == null) {
			MyCamera = GetComponent<MiCamara> ();
		}
	}
	public void ReloadCam2 (){
		if (Mycamera2 == null) {
			Mycamera2 = GetComponent<MiCamara2> ();
		}
	}

	public void DefinirPlayer (){
		if (ForceToStatic == true) {
			Player1 = this;
			SeePlayer1 = this;
		}
	}

	public void RecargaNodoPlayer (){
		
	}
}