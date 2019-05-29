using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuerzaCertera : MonoBehaviour {
	//Todos Estos Scripts son solo para IA

	public Rigidbody Rb;
	public NodoOnline MyOnlineNode;
	public Vector3 RightForce;

	// Use this for initialization
	void Start () {
		ReloadOnlineNode ();
	}
	
	// Update is called once per frame
	void Update () {
		ReloadOnlineNode ();
		ReloadRb ();
		OnFunctions ();
	}
	public void OnFunctions (){
		if (MyOnlineNode != null) {
			if (Rb != null) {
				
			}
		} else if (MyOnlineNode == null) {
			if (Rb != null) {
				Rb.AddRelativeForce (RightForce);
				Rb.velocity = Rb.velocity.normalized * 0f;
			}
		}
	}

	public void ReloadOnlineNode (){
		if (MyOnlineNode == null) {
			if (GetComponentInParent<NodoOnline> () != null) {
				MyOnlineNode = GetComponentInParent<NodoOnline> ();
			}
		}
	}
	public void ReloadRb (){
		if (Rb == null) {
			if (GetComponentInParent<MiPlayer> ().GetComponentInChildren<Rigidbody> () != null) {
				Rb = GetComponentInParent<MiPlayer> ().GetComponentInChildren<Rigidbody> ();
			}
		}
	}
	public void AplicandoFuerza (){

	}
	//Programado por: Romel Lucero El Papa de los Papas! jeje :D
	//Si lees esto gambate! mucho exito!
}
