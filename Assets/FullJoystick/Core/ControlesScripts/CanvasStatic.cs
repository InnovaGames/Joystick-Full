using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStatic : MonoBehaviour {

	public static CanvasStatic MyCanvasStatic;

	// Use this for initialization
	void Start () {
		ReloadCanvasStatic ();
	}
	
	// Update is called once per frame
	void Update () {
		ReloadCanvasStatic ();
	}

	public void ReloadCanvasStatic (){
		if (MyCanvasStatic == null) {
			MyCanvasStatic = this;
		}
	}
}