using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoPlayer : MonoBehaviour {

	public string[] AnimationTips = {"1. Cambiar el valor de AniNumeral[0] o AniBool[0] o AniFloat[0]", "2 Usar El Void: AnimationDefine (Midato, MiSetNombre)", "Para Animar desde cualquier Boton, Objeto, etc seguir estas instrucciones"};
	public GameObject MyFather;//Posiciones, rotaciones
	public GameObject JoyStickBase;
	public GameObject JoyStick;
	public string[] MyMessage = {"Si +JoystickDifference.y (Adelante)", "-JoystickDifference.y (atras)", "+JoystickDifference.x (Derecha)", "-JoystickDifference.x (Izquierda)"};
	public Vector3 JoystickDifference;
	private Vector3[] LocalJoystickPosition = new Vector3[2];
	public Vector3[] JoysticPosition = new Vector3[2];

	public Vector3 JoysticDegreesOut;
	public AnimacionCanvas[] MyAnimationCanvas;
	public FuerzaCanvas[] MyForceCanvas;
	public Animator MyAnimator;//Animaciones
	public Rigidbody Rb;//Fuerzas

	public float[] MyDistances;
	public float TriangleMostClose;
	public AnimacionCanvas RightTriangle;

	public bool JoysticOn;
	public int RightIndex;

	public int[] AniNumeral = {0, -1};
	public bool[] AniBool = {false,false};
	public float[] AniFloat = { 0f, 0f };

	// Use this for initialization
	void Start () {
		ReloadMyFather ();
		ReloadMyAnimationCanvas ();
		ReloadMyAnimator ();
		ReloadRb ();
		ReloadForceCanvas ();
		NormalizeRb ();
		DistancesIndex ();
	}
	// Update is called once per frame
	void Update () {
		ReloadMyFather ();
		ReloadMyAnimationCanvas ();
		ReloadMyAnimator ();
		ReloadRb ();
		ReloadForceCanvas ();
		JoystickDegreesOut ();
		JoyStickApplyDegrees ();
		NormalizeRb ();
		Triangulate ();
	}
	public void ReloadForceCanvas (){
		if (MyForceCanvas.Length == 0) {
			if (GetComponentInChildren<FuerzaCanvas> (true) != null) {
				MyForceCanvas = GetComponentsInChildren<FuerzaCanvas> (true);
			}
		}
	}

	public void DistancesIndex (){
		MyDistances = new float[MyAnimationCanvas.Length];
	}

	public void NormalizeRb (){
		if (Rb != null) {
			Rb.velocity = Rb.velocity.normalized * 0f;
		}
	}

	public void Triangulate (){
		if (JoysticOn == true) {
			LoadDistances ();
		}else if (JoysticOn == false) {
			if (RightTriangle != null) {
				RightTriangle.RestartAnimation ();
			}

			DeactivateAlls ();

		}
	}
	public void DeactivateAlls (){
		for (int i = 0; i < MyDistances.Length; i++) {
			MyAnimationCanvas [i].gameObject.SetActive (false);
		}
	}

	public void LoadDistances (){
		if (JoyStick != null) {

			TriangleMostClose = MyDistances [0];
			for (int i = 0; i < MyDistances.Length; i++) {
				MyAnimationCanvas [i].gameObject.SetActive (false);
				MyDistances [i] = Funciones.SacaDistancia (JoyStick.transform.position, MyAnimationCanvas[i].transform.position);
				if (MyDistances [i] < TriangleMostClose) {
					TriangleMostClose = MyDistances [i];
					RightTriangle = MyAnimationCanvas [i];
					RightIndex = i;
				}
			}
			if (RightTriangle != null) {
				RightTriangle.gameObject.SetActive (true);
				RightTriangle.TriggerAnimation ();
				Rb.AddRelativeForce(MyForceCanvas [RightIndex].ApplyLocalForce);
			}
		}
	}
	public void AnimationDefine (string MiDato, string MiSetNombre){
		if (AniNumeral [0] != AniNumeral [1]) {
			if (MiDato == "int") {
				MyAnimator.SetInteger (MiSetNombre, AniNumeral[0]);
				Debug.Log (MiDato + " + " + MiSetNombre + " + " + AniNumeral[0] + " CorriendoAnimacion: " + MyFather.name);
			}

			AniNumeral [1] = AniNumeral [0];
		}

		if (AniBool [0] != AniBool [1]) {
			if (MiDato == "bool") {
				MyAnimator.SetBool (MiSetNombre, AniBool [0]);

				Debug.Log (MiDato + " + " + MiSetNombre + " + " + "bool" + " CorriendoAnimacion: " + MyFather.name);
			}

			AniBool [1] = AniBool [0];
		}

		if (AniFloat [0] != AniFloat [1]) {
			if (MiDato == "float") {
				MyAnimator.SetFloat (MiSetNombre, AniFloat [0]);

				Debug.Log (MiDato + " + " + MiSetNombre + " + " + Mathf.Round (AniFloat[0]) + " CorriendoAnimacion: " + MyFather.name);
			}

			AniFloat [1] = AniFloat [0];
		}
	}

	public void JoyStickApplyDegrees (){
		if (MyFather != null) {
			if (Camera.main != null) {
				MyFather.transform.rotation = Quaternion.Euler (JoysticDegreesOut.x + 0f, JoysticDegreesOut.y + Camera.main.transform.rotation.eulerAngles.y, 0f);
			}
		}
	}

	public void JoystickDegreesOut (){
		LocalJoystickPosition [0] = JoyStickBase.transform.localPosition;
		LocalJoystickPosition [1] = JoyStick.transform.localPosition;
		JoysticPosition [0] = JoyStickBase.transform.position;
		JoysticPosition [1] = JoyStick.transform.position;


		// Conseguir Una Diferencia desde un punto 0 hasta > mayor a este
		JoystickDifference = JoysticPosition [1] - JoysticPosition [0];

		// El Punto Cero Virtual Imaginario;
		Vector3 MiVector = new Vector3 (0f, 0f, 0f);

		//Nuestra Simulacion De Distancias que van Desde un Punto 0;
		Vector3 MiV = new Vector3 (JoystickDifference.x, 0f, JoystickDifference.y);

		//JoysticDegreesOut = new Vector3 (0f, JoystickDifference.x + JoystickDifference.y, 0f);
		if (JoystickDifference.x + JoystickDifference.y + JoystickDifference.z != 0f) {
			JoysticOn = true;
		} else {
			JoysticOn = false;
		}

		if (JoysticOn == true) {
			JoysticDegreesOut = Funciones.SacaGrados (MiV, MiVector).eulerAngles;
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
	public void ReloadMyAnimator (){
		if (MyAnimator == null) {
			if (MyFather != null) {
				if (MyFather.GetComponentInChildren<Animator> (true) != null) {
					MyAnimator = MyFather.GetComponentInChildren<Animator> (true);
				}
			}
		}
	}
	public void ReloadMyAnimationCanvas (){
		if (MyAnimationCanvas.Length == 0) {
			if (GetComponentInChildren<AnimacionCanvas> (true) != null) {
				MyAnimationCanvas = GetComponentsInChildren<AnimacionCanvas> (true);
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