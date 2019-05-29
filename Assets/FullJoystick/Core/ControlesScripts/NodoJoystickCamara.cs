using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoJoystickCamara : MonoBehaviour {

	public GameObject MyFather;//Posiciones, rotaciones
	public GameObject JoyStickBase;
	public GameObject JoyStick;
	public string[] MyMessage = {"Si +JoystickDifference.y (Adelante)", "-JoystickDifference.y (atras)", "+JoystickDifference.x (Derecha)", "-JoystickDifference.x (Izquierda)"};
	public Vector3 JoystickDifference;
	public string[] MyMessage2 = { "Entre Mas Bajo Sea Joystic Offset", "Mas Sensible La Camara" };
	public Vector3 JoysticOffset = new Vector3 (50f, 50f, 50f);
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
	public int RightIndex;
	public Vector3 CameraLimits = new Vector3 (90f, 360f,0f);
	public float MiX;
	public float MiY;
	public float MiZ;
	public bool JoysticOn;

	public Vector3 NegV = new Vector3 (0f, 0f, -4f);

	// Use this for initialization
	void Start () {
		ReloadMyFather ();
		DistancesIndex ();
	}
	// Update is called once per frame
	void Update () {
		ReloadMyFather ();
		JoystickDegreesOut ();
		JoyStickApplyDegrees ();
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
		} else {
			if (RightTriangle != null) {
				RightTriangle.EnFuncionesAux (0, false, 0f);
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
				RightTriangle.ReloadAnimator ();
				RightTriangle.OnFunctions ();
				Rb.AddRelativeForce (MyForceCanvas [RightIndex].ApplyLocalForce);
			}
		}
	}
	public void JoyStickApplyDegrees (){
		if (MyFather != null) {
			if (Camera.main != null) {
				MiX += JoystickDifference.x / JoysticOffset.x;
				MiY += JoystickDifference.y / JoysticOffset.y;
				MiZ = 0f;

				if (MiY > CameraLimits.x) {
					MiY = CameraLimits.x;
				}
				if (MiY < -CameraLimits.x) {
					MiY = -CameraLimits.x;
				}
				MyFather.transform.rotation = Quaternion.Euler (MiY, MiX, MiZ);
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
			if (Camera.main != null) {
				MyFather = Camera.main.gameObject;
			}
		}
	}
}