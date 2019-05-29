using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmasIndexCanvas : MonoBehaviour {

	public Arma MyWeapon;

	// Use this for initialization
	void Start () {
		ReloadMyWeapon ();
	}
	
	// Update is called once per frame
	void Update () {
		ReloadMyWeapon ();

	}
	public void ChoseWeapon (int InventoryIndex){
		if (MyWeapon != null) {
			MyWeapon.InventoryIndex = InventoryIndex;
		}
	}
	public void ReloadMyWeapon (){
		if (MyWeapon == null) {
			if (PlayerStatico.Player1 != null) {
				if (PlayerStatico.Player1.GetComponentInParent<MiPlayer> ().GetComponentInChildren<Arma> ()) {
					MyWeapon = PlayerStatico.Player1.GetComponentInParent<MiPlayer> ().GetComponentInChildren<Arma> ();
				}
			}
		}
	}
}