using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiCamara : MonoBehaviour {

	public bool ForceToOut;
	public Vector3 PercentageRotation = new Vector3 (1f,1f,1f);
	public GameObject CameraSaved;
	public GameObject CameraNow;

	private Vector3 Rotations;
	private float[] RotationsSpeeds = {0f,0f,0f}; //x,y,z
	public float[] RotationsMagnitudes = {1f,1f,1f};

	private int[] CameraPixels = {0,0};
	private float[] ScreenCenter = {0f,0f};
	private float[] MousePosition = {0f,0f};
	private float[] MousePotency = {0f,0f,0f};
	public Vector3 RotationLimits = new Vector3 (90f, 360f, 0f);
	private float TmpX;
	private float TmpY;
	private float TmpZ;
	public Vector3 NegV = new Vector3 (0f, 0f, -4f);
	private Vector3 NegVSaved;

	public Vector3 NegRay;
	public RaycastHit MyHit;
	public LayerMask MyLayerHit;
	public float[] CoolDown = { 2f, 0f };
	public bool OnRecompose;
	public float RecomposeSpeed = 0.02f;

	// Use this for initialization
	void Start () {
		NegVSaved = NegV;
	}
	
	// Update is called once per frame
	void Update () {
		CameraOut ();
		if (CameraNow != null) {
			CameraPreventionBotton ();
		}
	}

	public void CameraPreventionBotton (){
		if (EventSystem.current.IsPointerOverGameObject (-1)) {

		} else {
			if (Input.GetKey (KeyCode.Mouse0)) {
				MouseRotation ();
				RotationDefine ();
			} else {
				Rotations = new Vector3 (0f, 0f, 0f);
			}

		}
		PositionDefine ();
		CameraCollision ();
	}

	public void CameraOut (){
		if (ForceToOut == true) {
			if (CameraNow == null) {
				CameraNow = Instantiate (CameraSaved, transform.rotation * NegV + transform.position, transform.rotation);
			}
		}
	}
	public void MouseRotation (){
		CameraPixels [0] = Camera.main.pixelHeight;
		CameraPixels [1] = Camera.main.pixelWidth;
		ScreenCenter [0] = CameraPixels [0] / 2;
		ScreenCenter [1] = CameraPixels [1] / 2;
		MousePosition[0] = Input.mousePosition.y - ScreenCenter[0];
		MousePosition[1] = Input.mousePosition.x - ScreenCenter[1];

		MousePotency [0] = MousePosition [0] / ScreenCenter [0];
		MousePotency [1] = MousePosition [1] / ScreenCenter [1];


		MousePotency [2] = Input.mousePosition.y/CameraPixels[0]; 

		RotationsSpeeds[0] = RotationsMagnitudes[0] * -MousePotency[0];
		RotationsSpeeds[2] = RotationsMagnitudes[2] * -MousePotency[1];
	}
	public void RotationDefine (){
		Rotations = new Vector3 (RotationsSpeeds [0] * PercentageRotation.x, -RotationsSpeeds [2] * PercentageRotation.y, -RotationsSpeeds [1] * PercentageRotation.z);


		TmpX += Rotations.x;
		TmpY += Rotations.y;
		TmpZ += Rotations.z;

		if (TmpX >= RotationLimits.x) {
			TmpX = RotationLimits.x;
		}
		if (TmpX <= -RotationLimits.x) {
			TmpX = -RotationLimits.x;
		}

		CameraNow.transform.rotation = Quaternion.Euler(TmpX,TmpY,TmpZ);

	}
	public void PositionDefine (){
		if (CameraNow != null) {
			CameraNow.transform.position = CameraNow.transform.rotation * NegV + transform.position;
		}
	}

	public void CameraCollision (){
		if (Physics.Linecast (transform.position + NegRay, CameraNow.transform.position, out MyHit, MyLayerHit.value)) {
			Debug.DrawLine (transform.position + NegRay, CameraNow.transform.position, Color.red);
			NegV = new Vector3 (NegV.x, NegV.y, -MyHit.distance);
			CoolDown [1] = Time.time;
			OnRecompose = true;
		} else {
			Debug.DrawLine (transform.position + NegRay, CameraNow.transform.position, Color.green);
		}
		if (Time.time < CoolDown [0] + CoolDown [1]) {

		} else {
			if (OnRecompose == true) {
				if (NegV.z > NegVSaved.z) {
					NegV = new Vector3 (NegV.x, NegV.y, NegV.z - RecomposeSpeed);
				} else {
					OnRecompose = false;
				}
			}
		}
	}
}