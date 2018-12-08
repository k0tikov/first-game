using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	/*public Transform target;
	
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void LateUpdate() {
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	}*/
	public Transform target;
	
	private Vector3 offset;
	
	[Range(0.01f, 1.0f)]
	public float smooth = 0.5f;
	
	void Start() {
		offset = transform.position - target.position;
	}
	void LateUpdate() {
		Vector3 newPos = target.position + offset;
		transform.position = Vector3.Slerp(transform.position, newPos, smooth);
	}		
	
}
