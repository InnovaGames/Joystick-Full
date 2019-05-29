using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCanvas : MonoBehaviour {

	public NodoPlayer MyPlayerNode;
	public Animator MyAnimator;
	public string DataType = "int";//"int","bool","float"
	public string MyNameIntSet;
	public int MyIntSet;
	public string MyNameBoolSet;
	public bool MySetBool;
	public string MyNameFloatSet;
	public float MyFloatSet;

	public int RestartNumeralAnimation;
	public bool RestartAnimationBool;
	public float RestartAnimationFloat;

	void Start () {
		ReloadPlayerNode ();
		ReloadAnimator ();
	}
	void Update () {
		ReloadPlayerNode ();
		ReloadAnimator ();
	}
	public void ReloadPlayerNode (){
		if (MyPlayerNode == null) {
			if (GetComponentInParent<NodoPlayer> () != null) {
				MyPlayerNode = GetComponentInParent<NodoPlayer> ();
			}
		}
	}
	public void RestartAnimation (){
		if (MyAnimator != null) {
			if (MyPlayerNode != null) {
				if (MyPlayerNode.JoysticOn == false) {
					if (DataType == "int") {
						MyPlayerNode.AniNumeral [0] = RestartNumeralAnimation;
						MyPlayerNode.AnimationDefine (DataType, MyNameIntSet);
					}
					if (DataType == "bool") {
						MyPlayerNode.AniBool [0] = RestartAnimationBool;
						MyPlayerNode.AnimationDefine (DataType, MyNameBoolSet);
					}
					if (DataType == "float") {
						MyPlayerNode.AniFloat [0] = RestartAnimationFloat;
						MyPlayerNode.AnimationDefine (DataType, MyNameFloatSet);
					}
				}
			}
		}
	}
	public void TriggerAnimation (){
		if (MyAnimator != null) {
			if (MyPlayerNode != null) {
				if (DataType == "int") {
					MyPlayerNode.AniNumeral [0] = MyIntSet;
					MyPlayerNode.AnimationDefine (DataType, MyNameIntSet);
				}
				if (DataType == "bool") {
					MyPlayerNode.AniBool [0] = MySetBool;
					MyPlayerNode.AnimationDefine (DataType, MyNameBoolSet);
				}
				if (DataType == "float") {
					MyPlayerNode.AniFloat [0] = MyFloatSet;
					MyPlayerNode.AnimationDefine (DataType, MyNameFloatSet);
				}
			}
		}
	}

	public void OnFunctions (){
		if (MyAnimator != null) {
			if (DataType == "int") {
				MyAnimator.SetInteger (MyNameIntSet, MyIntSet);
			}
			if (DataType == "bool") {
				MyAnimator.SetBool (MyNameBoolSet, MySetBool);
			}
			if (DataType == "float") {
				MyAnimator.SetFloat (MyNameFloatSet, MyFloatSet);
			}
		}
	}
	public void EnFuncionesAux (int MiInt, bool MiBool, float MiFloat){
		if (MyAnimator != null) {
			if (DataType == "int") {
				MyAnimator.SetInteger (MyNameIntSet, MiInt);
			}
			if (DataType == "bool") {
				MyAnimator.SetBool (MyNameBoolSet, MiBool);
			}
			if (DataType == "float") {
				MyAnimator.SetFloat (MyNameFloatSet, MiFloat);
			}
		}
	}
	public void ReloadAnimator (){
		if (MyAnimator == null) {
			if (PlayerStatico.Player1 != null) {
				if (PlayerStatico.Player1.GetComponentInChildren<Animator> (true) != null) {
					MyAnimator = PlayerStatico.Player1.GetComponentInChildren<Animator> (true);
				}
			}
		}
	}
}