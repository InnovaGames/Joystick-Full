using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NodoOnline : MonoBehaviour {
	//Todos Estos Scripts son solo para IA
	//trabajando de Server a ClientesTodos

	//AQUI SE CALCULAN LAS POSICIONES TAMBIEN!

	public bool NetWorkServerSpawn;
	public Rigidbody Rb;
	public Animator MyAnimator;
	public Animation MyAnimation;
	public float MyAngularDrag = 3f;
	
	public Vector3 Position0;
	public float miX;
	public float miY;
	public float miZ;

	// Use this for initialization
	void Start () {
		IaNetSpawn ();
	}

	public void IaNetSpawn (){

	}

	// Update is called once per frame
	void Update () {
		ReloadAnimators ();
		ReloadRb ();
	}
	public void ReloadRb (){
		if (Rb == null) {
			if (GetComponentInParent<MiPlayer> ().GetComponentInChildren<Rigidbody> () != null) {
				Rb = GetComponentInParent<MiPlayer> ().GetComponentInChildren<Rigidbody> ();
			}
		}
	}
	public void ReloadAnimators (){
		if (MyAnimator == null) {
			if (GetComponentInParent<MiPlayer> ().GetComponentInChildren<Animator> (true) != null) {
				MyAnimator = GetComponentInParent<MiPlayer> ().GetComponentInChildren<Animator> (true);
			}
		}
		if (MyAnimation == null) {
			if (GetComponentInParent<MiPlayer> ().GetComponentInChildren<Animation> () != null) {
				MyAnimation = GetComponentInParent<MiPlayer> ().GetComponentInChildren<Animation> ();

			}
		}
	}

	
	public void RpcPasarAnimation (){

	}

	public void PasarAnimation (){
		
	}
	/// <summary>
	/// NO USAR! DESDE OTRO METODO! Comparte a todos los clientes La Animacion de este Objeto (SetNombre = Nombre del parametro de tu animacion), (SetValor = el valor que le quieres Dar).
	/// </summary>
	/// <param name="SetNombre1">Set Nombre1.</param>
	/// <param name="SetValor1">Set Valor1.</param>
	
	public void RpcPasarAnimacionIAint (string SetNombre, int SetValor){
		MyAnimator.SetInteger (SetNombre, SetValor);
	}
	/// <summary>
	/// ANIMATOR. Este Metodo Es para que la consulta se haga dentro del objeto al que llamas y no desde el convocante o sea para que no se haga desde donde me estas llamando, sino, donde me encuento se ejecute el RPC.
	/// </summary>
	/// <param name="SetNombre0">Set nombre0.</param>
	/// <param name="SetValor0">Set valor0.</param>
	public void PasarAnimacionIAint (string SetNombre, int SetValor){
		RpcPasarAnimacionIAint (SetNombre, SetValor);
	}

	/// <summary>
	/// NO USAR! DESDE OTRO METODO! Comparte a todos los clientes La Animacion de este Objeto (SetNombre = Nombre del parametro de tu animacion), (SetValor = el valor que le quieres Dar).
	/// </summary>
	/// <param name="SetNombre">Set nombre.</param>
	/// <param name="SetValor">If set to <c>true</c> set valor.</param>
	
	public void RpcPasarAnimacionIAbool (string SetNombre, bool SetValor){
		MyAnimator.SetBool (SetNombre, SetValor);
	}
	/// <summary>
	/// ANIMATOR. Este Metodo Es para que la consulta se haga dentro del objeto al que llamas y no desde el convocante o sea para que no se haga desde donde me estas llamando, sino, donde me encuento se ejecute el RPC.
	/// </summary>
	/// <param name="SetNombre">Set nombre.</param>
	/// <param name="SetValor">If set to <c>true</c> set valor.</param>
	public void PasarAnimacionIAbool (string SetNombre, bool SetValor){
		RpcPasarAnimacionIAbool (SetNombre, SetValor);
	}
	/// <summary>
	/// NO USAR! DESDE OTRO METODO! Comparte a todos los clientes La Animacion de este Objeto (SetNombre = Nombre del parametro de tu animacion), (SetValor = el valor que le quieres Dar).
	/// </summary>
	/// <param name="SetNombre">Set nombre.</param>
	/// <param name="SetValor">Set valor.</param>
	
	public void RpcPasarAnimacionIAfloat (string SetNombre, float SetValor){
		MyAnimator.SetFloat (SetNombre, SetValor);
	}
	/// <summary>
	/// ANIMATOR. Este Metodo Es para que la consulta se haga dentro del objeto al que llamas y no desde el convocante o sea para que no se haga desde donde me estas llamando, sino, donde me encuento se ejecute el RPC.
	/// </summary>
	/// <param name="SetNombre">Set nombre.</param>
	/// <param name="SetValor">Set valor.</param>
	public void PasarAnimacionIAfloat (string SetNombre, float SetValor){
		RpcPasarAnimacionIAfloat (SetNombre, SetValor);
	}
	/// <summary>
	/// NO USAR! DESDE OTRO METODO! Fueza = lo fuerza Local a aplicar, Normalized = entre mas alto sea el numero mas patinara en el suelo, o sea, mayor la incercia.
	/// </summary>
	/// <param name="Fuerza">Fuerza.</param>
	/// <param name="Normalized">Normalized.</param>
	
	public void RpcPasarFuerzasIA (Vector3 Fuerza, float Normalized){
		Rb.AddRelativeForce (Fuerza);
		Rb.velocity = Rb.velocity.normalized * Normalized;
	}
	/// <summary>
	/// RIGIDBODY. Fueza = lo fuerza Local a aplicar, Normalized = entre mas alto sea el numero mas patinara en el suelo, o sea, mayor la incercia.
	/// </summary>
	/// <param name="Fuerza">Fuerza.</param>
	/// <param name="Normalized">Normalized.</param>
	public void PasarFuerzasIA (Vector3 Fuerza, float Normalized){
		RpcPasarFuerzasIA (Fuerza, Normalized);
	}

	/// <summary>
	/// NO USAR! DESDE OTRO METODO! Quaternion = Rotaciones Basadas en 4 vectores del 0 al 1 los tres primeros para cada rotacion y el ultimo para su posicion relativa Rotacion Euler = Rotaciones en Base a 360 grados o Rotaciones de 360/2 = 180 && -180 partiendo desde 0 tambien
	/// </summary>
	/// <param name="RotacionEuler">Rotacion euler.</param>
	
	public void RpcPasarRotacionIA (Quaternion RotacionEuler){
		transform.rotation = RotacionEuler;
	}
	/// <summary>
	/// TRANSFORM.ROTATION. Quaternion = Rotaciones Basadas en 4 vectores del 0 al 1 los tres primeros para cada rotacion y el ultimo para su posicion relativa,  Rotacion Euler = Rotaciones en Base a 360 grados o Rotaciones de 360/2 = 180 && -180 partiendo desde 0 tambien
	/// </summary>
	/// <param name="RotacionEuler">Rotacion euler.</param>
	public void PasarRotacionIA (Quaternion RotacionEuler){
		RpcPasarRotacionIA (RotacionEuler);
	}
	/// <summary>
	/// TRANSFORM.POSITION. Mediante una Variable Sincronizada (Position0) pasamos valores a todos los clientes que serviran para calcular de manera suave la posicion correcta donde se encuentra la mascota en todos los clientes.
	/// </summary>
	/// <param name="Posicion">Posicion.</param>
	public void ReturnPosition (){
		//if (isServer == true) {
			Position0 = transform.position;

		//} else if (isServer == false) {
			miX = Position0.x - transform.position.x;//por rb(Rpo / Position) -1f;  + es mayor - es menor
			miY = Position0.y - transform.position.y;//+ es mayor - es menor
			miZ = Position0.z - transform.position.z;//+ es mayor - es menor


			transform.position = new Vector3 (transform.position.x + (miX/MyAngularDrag), transform.position.y + (miY/MyAngularDrag), transform.position.z + (miZ/MyAngularDrag));
		//}
	}
	//Programado por: Romel Lucero El Papa de los Papas! jeje :D
	//Si lees esto gambate! mucho exito!
}