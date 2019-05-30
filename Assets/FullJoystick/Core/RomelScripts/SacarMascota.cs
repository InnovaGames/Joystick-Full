using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SacarMascota : MonoBehaviour {

	public Vector3 MyRandoms = new Vector3 (2f, 0f, 2f);
	public GameObject[] MyPet = { null, null };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.K)) {
			//PetSpawn ();
		}
	}
	public void PetSpawn (){
		if (MyPet [1] != null) {
			Destroy (MyPet [1], 0f);
		}
		MyPet [1] = Instantiate (MyPet [0], transform.position + new Vector3 (Random.Range (-MyRandoms.x,MyRandoms.x), transform.position.y, Random.Range(-MyRandoms.z, MyRandoms.z)), transform.rotation);
		MyPet [1].GetComponentInParent<MiPlayer> ().GetComponentInChildren<NodoIA2> ().Target = gameObject;
	}
}