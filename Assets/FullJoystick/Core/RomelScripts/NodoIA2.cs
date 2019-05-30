using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoIA2 : MonoBehaviour {
	//Todos Estos Scripts son solo para IA
	public bool DirectRotation;
	public float DirectForce;
	public float DirectNormalized;
	public int DirectAnimation = 1;
	public Animator MyDirectAnimator;
	public string MyDirectAnimatorName;
	public Rigidbody Rb;

	public GameObject MyFather;
	public GameObject Target;
	public NodoOnline MyOnlineNode;
	public int[] ReloadTime = {0, 60};
	public GameObject[] MyTriangulations;
	public float[] MyDistances;
	public float TriangleMostClose;
	public GameObject RightTriangle;
	public float StopLimit = 1.5f;

	public int[] AniNumeral = {0, -1};
	public bool[] AniBool = {false,false};
	public float[] AniFloat = { 0f, 0f };

	// Use this for initialization
	void Start () {
		ReloadAnimators ();
		ReloadOnlineNode ();
		MyDistances = new float[transform.childCount];
		MyTriangulations = new GameObject[transform.childCount];
		LoadTriangulations ();
		ReloadFather ();
		ReloadRb ();
	}
	
	// Update is called once per frame
	void Update () {
		ReloadAnimators ();
		ReloadFather ();
		OnFunctions ();
		ReloadRb ();
	}
	public void ReloadAnimators (){
		if (MyDirectAnimator == null) {
			if (GetComponentInParent<MiPlayer> ().GetComponentInChildren<Animator> (true) != null) {
				MyDirectAnimator = GetComponentInParent<MiPlayer> ().GetComponentInChildren<Animator> (true);
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
	public void ReloadFather (){
		if (MyFather == null) {
			if (GetComponentInParent<MiPlayer> () != null) {
				MyFather = GetComponentInParent<MiPlayer> ().gameObject;
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
	public void OnCoolDown (){
		ReloadTime [0] += 1;

		if (ReloadTime [0] > ReloadTime [1]) {
			LoadDistances ();
			ReloadTime [0] = 0;
		}
	}

	public void AnimationDefine (string MiDato, string MiSetNombre){
		if (AniNumeral [0] != AniNumeral [1]) {
			if (MiDato == "int") {
				MyDirectAnimator.SetInteger (MiSetNombre, AniNumeral[0]);
				Debug.Log (MiDato + " + " + MiSetNombre + " + " + AniNumeral[0] + " CorriendoAnimacion: " + MyFather.name);
			}

			AniNumeral [1] = AniNumeral [0];
		}

		if (AniBool [0] != AniBool [1]) {
			if (MiDato == "bool") {
				MyDirectAnimator.SetBool (MiSetNombre, AniBool [0]);

				Debug.Log (MiDato + " + " + MiSetNombre + " + " + "bool" + " CorriendoAnimacion: " + MyFather.name);
			}

			AniBool [1] = AniBool [0];
		}

		if (AniFloat [0] != AniFloat [1]) {
			if (MiDato == "float") {
				MyDirectAnimator.SetFloat (MiSetNombre, AniFloat [0]);

				Debug.Log (MiDato + " + " + MiSetNombre + " + " + Mathf.Round (AniFloat[0]) + " CorriendoAnimacion: " + MyFather.name);
			}

			AniFloat [1] = AniFloat [0];
		}
	}
	public void RotacionPura (){

	}

	public void OnFunctions (){

		if (DirectRotation == false) {
			OnCoolDown ();
		}
		if (DirectRotation == true) {
			if (MyOnlineNode != null) {
				
					TriangulationOff ();
					Quaternion TempQ = Funciones.SacaGrados (Target.transform.position, MyFather.transform.position);
					MyFather.transform.rotation = Quaternion.Euler (0f, TempQ.eulerAngles.y, 0f);
					MyOnlineNode.PasarRotacionIA (MyFather.transform.rotation);

					//fuerza directa
					if (Funciones.SacaDistancia (Target.transform.position, MyFather.transform.position) > StopLimit) {
						Rb.AddRelativeForce (0f, 0f, DirectForce);
						Rb.velocity = Rb.velocity.normalized * DirectNormalized;
						MyDirectAnimator.SetInteger (MyDirectAnimatorName, DirectAnimation);
						MyOnlineNode.PasarAnimacionIAint (MyDirectAnimatorName, DirectAnimation);
					} else {
						Rb.AddRelativeForce (0f, 0f, 0f);
						Rb.velocity = Rb.velocity.normalized * DirectNormalized;

						MyDirectAnimator.SetInteger (MyDirectAnimatorName, 0);
						MyOnlineNode.PasarAnimacionIAint (MyDirectAnimatorName, 0);
					}
				
			}
			if (MyOnlineNode == null) {
				TriangulationOff ();
				Quaternion TempQ = Funciones.SacaGrados (Target.transform.position, MyFather.transform.position);
				MyFather.transform.rotation = Quaternion.Euler (0f, TempQ.eulerAngles.y, 0f);

				//fuerza directa
				if (Funciones.SacaDistancia (Target.transform.position, MyFather.transform.position) > StopLimit) {
					Rb.AddRelativeForce (0f, 0f, DirectForce);
					Rb.velocity = Rb.velocity.normalized * DirectNormalized;
					MyDirectAnimator.SetInteger (MyDirectAnimatorName, DirectAnimation);
				}else {
					Rb.AddRelativeForce (0f, 0f, 0f);
					Rb.velocity = Rb.velocity.normalized * DirectNormalized;
					MyDirectAnimator.SetInteger (MyDirectAnimatorName, 0);
				}
			}
		}
	}
	public void TriangulationOff(){
		for (int i = 0; i < MyTriangulations.Length; i++) {
			if (MyTriangulations [i].activeInHierarchy == true) {
				MyTriangulations [i].SetActive (false);
			}
		}
	}

	public void LoadDistances (){
		if (Target != null) {
			if (RightTriangle != null) {
				//RightTriangle.SetActive (false);

			}

			TriangleMostClose = MyDistances [0];
			for (int i = 0; i < MyDistances.Length; i++) {
				MyTriangulations [i].SetActive (false);
				MyDistances [i] = Funciones.SacaDistancia (Target.transform.position, MyTriangulations [i].transform.position);
				if (MyDistances [i] < TriangleMostClose) {
					TriangleMostClose = MyDistances [i];
					RightTriangle = MyTriangulations [i];

				}
			}
			if (RightTriangle != null) {
				RightTriangle.SetActive (true);
			}
		}
	}

	public void LoadTriangulations (){
		for (int i = 0; i < MyTriangulations.Length; i++) {
			MyTriangulations [i] = transform.GetChild (i).gameObject;
		}
	}
	//Programado por: Romel Lucero El Papa de los Papas! jeje :D
	//Si lees esto gambate! mucho exito!
}