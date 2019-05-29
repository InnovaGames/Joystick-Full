using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiCamara2 : MonoBehaviour {

	public bool ForceToOut;
	public GameObject CameraSaved;
	public GameObject CameraNow;
	public GameObject JoysticCameraSaved;
	public GameObject JoysticCameraNow;
	public NodoOnline MyOnlineNode;

	public Vector3 NegRay;
	public RaycastHit MyHit;
	public LayerMask MyLayerHit;
	public float[] CoolDown = { 2f, 0f };
	public bool OnRecompose;
	public float RecomposeSpeed = 0.02f;
	public Vector3 NegV = new Vector3 (0f, 0f, -4f);
	public Vector3 NegVSaved;


	// Use this for initialization
	void Start () {
		NegVSaved = NegV;
		ReloadOnlineNode();
		CameraOut ();
		JoystickCameraOut ();
	}
	
	// Update is called once per frame
	void Update () {
		ReloadOnlineNode ();
		CameraOut ();
		JoystickCameraOut ();
		//CameraCollision ();
		DefinePosition ();
	}

	public void JoystickCameraOut (){
		if (JoysticCameraNow == null) {
			if (ForceToOut == true) {
				JoysticCameraNow = Instantiate (JoysticCameraSaved, JoystickCamaraSpot.MiYo.transform.position, Quaternion.identity, JoystickCamaraSpot.MiYo.transform);
			}
		}
	}

	public void CameraOut (){
		if (CameraNow == null) {
			if (ForceToOut == true) {
				CameraNow = Instantiate (CameraSaved, transform.rotation * NegV + transform.position, transform.rotation);
			}
		}
	}
	public void DefinePosition (){
		CameraNow.transform.position = CameraNow.transform.rotation * NegV + transform.position;
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
	public void ReloadOnlineNode (){
		if (MyOnlineNode == null) {
			if (GetComponentInParent<NodoOnline> () != null) {
				MyOnlineNode = GetComponentInParent<NodoOnline> ();
			}
		}
	}
}