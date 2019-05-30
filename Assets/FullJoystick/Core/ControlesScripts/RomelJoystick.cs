using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RomelJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	// Use this for initialization
	void Start () {
		
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	public virtual void OnDrag(PointerEventData eventData){
		transform.position = Input.mousePosition;
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		transform.position = transform.parent.position;
	}
}