﻿using UnityEngine.EventSystems;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
	
	public Interactable focus;
	//Camera cam;
	//public LayerMask movementMask;
	PlayerMotor motor;
	
	void Start() {
		//cam = Camera.main;	
		motor = GetComponent<PlayerMotor>();
	}
	
	void Update(){
		
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		
		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 100)) {
				motor.MoveToPoint(hit.point);
				
				RemoveFocus();
			}
		}
		if (Input.GetMouseButtonDown(1)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 100)) {
				Interactable interactable = hit.collider.GetComponent<Interactable>();
				
				if(interactable != null) {
					SetFocus(interactable);
				}
			}
		}
	}
	void SetFocus(Interactable newFocus){
		if (newFocus != focus) {
			if (focus != null) {
				focus.OnDeFocused();
			}
			focus = newFocus;
			motor.FollowTarget(newFocus);
		}
		newFocus.OnFocused(transform);
	}
	void RemoveFocus() {
		if (focus != null) {
			focus.OnDeFocused();
		}
		focus = null;
		motor.StopFollowingTarget();
	}
}