using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiPlayer : MonoBehaviour {

	public GameObject Parenting;
	public GameObject MySpawnPlayer;
	public GameObject MyOut;

	// Use this for initialization
	void Start () {
		MyOut = Instantiate (MySpawnPlayer, Parenting.transform);
		MyOut.transform.localPosition = new Vector3 (0f, 0f, 0f);
		MyOut.transform.localRotation = Quaternion.Euler (0f, 0f, 0f);
		MyOut.transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	// Update is called once per frame
	void Update () {

	}
}