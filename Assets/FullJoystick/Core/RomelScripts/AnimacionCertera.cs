using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCertera : MonoBehaviour {

	//Todos Estos Scripts son solo para IA
	//All these scripst are only for IA

	//estos scripts "certeros" solo se activan un tiempo y se desactivan y asi
	//This scripts "certera" only activated for just a time and deactivated

	public NodoIA2 MyIaNode;
	public NodoOnline MyOnlineNode;
	public string DataType = "int";//"int","bool","float"
	public string MyNameIntSet;
	public int MyIntSet;
	public string MyNameBoolSet;
	public bool MyBoolSet;
	public string MyNameFloatSet;
	public float MiSetFloat;
	public Animator MyAnimator;

	public int RestartNumeralAnimation;
	public bool RestartAnimationBool;
	public float RestartAnimationFloat;

	// Use this for initialization
	void Start () {
		ReloadIaNode ();
		ReloadOnlineNode ();
		ReloadAnimators ();
	}
	
	// Update is called once per frame
	void Update () {
		ReloadIaNode ();
		ReloadAnimators ();
		TriggerAnimation ();
		//OnFunctions (DataType);
	}
	public void RestartAnimation (){
		if (MyAnimator != null) {
			if (MyIaNode != null) {
				if (DataType == "int") {
					MyIaNode.AniNumeral [0] = RestartNumeralAnimation;
					MyIaNode.AnimationDefine (DataType, MyNameIntSet);
				}
				if (DataType == "bool") {
					MyIaNode.AniBool [0] = RestartAnimationBool;
					MyIaNode.AnimationDefine (DataType, MyNameBoolSet);
				}
				if (DataType == "float") {
					MyIaNode.AniFloat [0] = RestartAnimationFloat;
					MyIaNode.AnimationDefine (DataType, MyNameFloatSet);
				}

			}
		}
	}
	public void TriggerAnimation (){
		if (MyAnimator != null) {
			if (MyIaNode != null) {
				if (DataType == "int") {
					MyIaNode.AniNumeral [0] = MyIntSet;
					MyIaNode.AnimationDefine (DataType, MyNameIntSet);
				}
				if (DataType == "bool") {
					MyIaNode.AniBool [0] = MyBoolSet;
					MyIaNode.AnimationDefine (DataType, MyNameBoolSet);
				}
				if (DataType == "float") {
					MyIaNode.AniFloat [0] = MiSetFloat;
					MyIaNode.AnimationDefine (DataType, MyNameFloatSet);
				}
			}
		}
	}
	public void ReloadIaNode (){
		if (MyIaNode == null) {
			if (GetComponentInParent<NodoIA2> () != null) {
				MyIaNode = GetComponentInParent<NodoIA2> ();
			}
		}
	}

	public void OnFunctions (string MiDato){
		if (MyOnlineNode != null) {
			if (MyAnimator != null) {
				
					if (MiDato == "int") {
						MyAnimator.SetInteger (MyNameIntSet, MyIntSet);
						MyOnlineNode.PasarAnimacionIAint (MyNameIntSet, MyIntSet);
					}
					if (MiDato == "bool") {
						MyAnimator.SetBool (MyNameBoolSet, MyBoolSet);
						MyOnlineNode.PasarAnimacionIAbool (MyNameBoolSet, MyBoolSet);
					}
					if (MiDato == "float") {
						MyAnimator.SetFloat (MyNameFloatSet, MiSetFloat);
						MyOnlineNode.PasarAnimacionIAfloat (MyNameFloatSet, MiSetFloat);
					}

				
			}

		} else {

			if (MyAnimator != null) {
				if (MiDato == "int") {
					MyAnimator.SetInteger (MyNameIntSet, MyIntSet);
				}
				if (MiDato == "bool") {
					MyAnimator.SetBool (MyNameBoolSet, MyBoolSet);
				}
				if (MiDato == "float") {
					MyAnimator.SetFloat (MyNameFloatSet, MiSetFloat);
				}

			}
		}
	}


	public void ReloadAnimators (){
		if (MyAnimator == null) {
			if (GetComponentInParent<MiPlayer> ().GetComponentInChildren<Animator> (true) != null) {
				MyAnimator = GetComponentInParent<MiPlayer> ().GetComponentInChildren<Animator> (true);
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
	//Programado por: Romel Lucero El Papa de los Papas! jeje :D
	//Si lees esto gambate! mucho exito!
}