using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCertera : MonoBehaviour {

	//Todos Estos Scripts son solo para IA
	public GameObject MyFather;
	public NodoOnline MyOnlineNode;
	public Vector3 RightRotation;
	public bool Evading;
	public int Invert = 1;

	public RaycastHit MyHit;
	public LayerMask MyLayer;

	public Vector3 PositionMax;
	public float CorrectSpeed = 0.1f;

	public NodoIA2 MyIaNode;

	// Use this for initialization
	void Start () {
		ReloadIaNode ();
		ReloadFather ();
		ReloadOnlineNode ();
	}
	
	// Update is called once per frame
	void Update () {
		ReloadIaNode ();
		ActulizaEvasion ();
		ReloadFather ();
		ReloadOnlineNode ();
		OnFunctions ();
		CrearRayCast ();
		
	}
	public void ReloadIaNode (){
		if (MyIaNode == null) {
			if (GetComponentInParent<MiPlayer> ().GetComponentInChildren<NodoIA2> ()) {
				MyIaNode = GetComponentInParent<MiPlayer> ().GetComponentInChildren<NodoIA2> ();
			}
		}
	}

	public void AcercaLocal (){
		if (transform.localPosition.x > 0f) {
			transform.localPosition += new Vector3 (-CorrectSpeed, 0f, 0f);
		}
		if (transform.localPosition.y > 0f) {
			transform.localPosition += new Vector3 (0f, -CorrectSpeed, 0f);
		}
		if (transform.localPosition.z > 0f) {
			transform.localPosition += new Vector3 (0f, 0f, -CorrectSpeed);
		}
		if (transform.localPosition.x < 0f) {
			transform.localPosition += new Vector3 (CorrectSpeed, 0f, 0f);
		}
		if (transform.localPosition.y < 0f) {
			transform.localPosition += new Vector3 (0f, CorrectSpeed, 0f);
		}
		if (transform.localPosition.z < 0f) {
			transform.localPosition += new Vector3 (0f, 0f, CorrectSpeed);
		}
	}
	public void AlejaLocal () {
		if (transform.localPosition.x < PositionMax.x) {
			transform.localPosition += new Vector3 (CorrectSpeed, 0f, 0f);
		}
		if (transform.localPosition.y < PositionMax.y) {
			transform.localPosition += new Vector3 (0f, CorrectSpeed, 0f);
		}
		if (transform.localPosition.z < PositionMax.z) {
			transform.localPosition += new Vector3 (0f, 0f, CorrectSpeed);
		}
		if (transform.localPosition.x > PositionMax.x) {
			transform.localPosition += new Vector3 (-CorrectSpeed, 0f, 0f);
		}
		if (transform.localPosition.y > PositionMax.y) {
			transform.localPosition += new Vector3 (0f, -CorrectSpeed, 0f);
		}
		if (transform.localPosition.z > PositionMax.z) {
			transform.localPosition += new Vector3 (0f, 0f, -CorrectSpeed);
		}
	}

	public void CrearRayCast (){
		if (Physics.Linecast (MyFather.transform.position, transform.position, out MyHit, MyLayer.value)) {
			Evading = true;

			AcercaLocal ();

			for (int i = 0; i < MyIaNode.MyTriangulations.Length; i++) {
				MyIaNode.MyTriangulations [i].GetComponent<RotacionCertera> ().AcercaLocal ();
			}

			Debug.DrawLine (MyFather.transform.position, transform.position, Color.red);
		} else {
			Evading = false;

			AlejaLocal ();

			for (int i = 0; i < MyIaNode.MyTriangulations.Length; i++) {
				MyIaNode.MyTriangulations [i].GetComponent<RotacionCertera> ().AlejaLocal ();
			}

			Debug.DrawLine (MyFather.transform.position, transform.position, Color.green);
		}
	}

	public void ActulizaEvasion (){
		if (Evading == true) {
			Invert = -1;
		} else if (Evading == false) {
			Invert = 0;
		}
	}

	public void ReloadFather (){
		if (MyFather == null) {
			if (GetComponentInParent<MiPlayer> () != null) {
				MyFather = GetComponentInParent<MiPlayer> ().gameObject;
			}
		}
	}

	public void OnFunctions (){
		if (MyOnlineNode != null) {
			if (MyOnlineNode != null) {
				
					if (Evading == false) {
						MyFather.transform.Rotate (RightRotation);
						MyOnlineNode.PasarRotacionIA (MyFather.transform.rotation);
					} else {
						MyFather.transform.Rotate (0f, Invert, 0f);
						MyOnlineNode.PasarRotacionIA (MyFather.transform.rotation);
					}
				
			}
		} else if (MyOnlineNode == null) {
			if (Evading == false) {
				MyFather.transform.Rotate (RightRotation);

			} else {
				MyFather.transform.Rotate (0f, Invert, 0f);
			}
		}
	}
	public void ReloadOnlineNode ()
	{
		if (MyOnlineNode == null) {
			if (GetComponentInParent<NodoOnline> () != null) {
				MyOnlineNode = GetComponentInParent<NodoOnline> ();
			}
		}
	}
	public void OnTriggerStay (Collider col){
		Evading = true;
	}
	public void OnTriggerExit (){
		Evading = false;
	}

	//Programado por: Romel Lucero El Papa de los Papas! jeje :D
	//Si lees esto gambate! mucho exito!
}
