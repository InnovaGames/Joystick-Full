using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

	public bool IamLeftHanded;
	public GameObject WeaponNow;
	public ManoDerecha MyRightHand;
	public ManoIzquierda MyLeftHand;
	public GameObject[] Inventory = {null,null,null};
	public int InventoryIndex;
	private int RememberIndex = -1;

	// Use this for initialization
	void Start () {
		ReloadRightHand ();
		ReloadLeftHand ();
	}
	
	// Update is called once per frame
	void Update () {
		ReloadRightHand ();
		ReloadLeftHand ();
		ReloadIndex ();
	}

	public void LoadWeapon (){
		if (WeaponNow != null) {
			Destroy (WeaponNow, 0f);
		}

		if (IamLeftHanded == false) {
			WeaponNow = Instantiate (Inventory [InventoryIndex], MyRightHand.transform.position, MyRightHand.transform.rotation * Inventory[InventoryIndex].transform.rotation,  MyRightHand.transform);

		} else if (IamLeftHanded == true) {
			WeaponNow = Instantiate (Inventory [InventoryIndex], MyLeftHand.transform.position, MyLeftHand.transform.rotation * Inventory[InventoryIndex].transform.rotation, MyLeftHand.transform);

		}
	}

	public void ReloadIndex (){
		if (InventoryIndex != RememberIndex) {
			LoadWeapon ();

			RememberIndex = InventoryIndex;
		}
	}

	public void ReloadRightHand(){
		if (MyRightHand == null) {
			if (GetComponentInParent<MiPlayer> ().GetComponentInChildren<ManoDerecha> ()) {
				MyRightHand = GetComponentInParent<MiPlayer> ().GetComponentInChildren<ManoDerecha> ();
			}
		}
	}
	public void ReloadLeftHand (){
		if (MyLeftHand == null) {
			if (GetComponentInParent<MiPlayer> ().GetComponentInChildren<ManoIzquierda> ()) {
				MyLeftHand = GetComponentInParent<MiPlayer> ().GetComponentInChildren<ManoIzquierda> ();
			}
		}
	}
}