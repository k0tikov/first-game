using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour {
	
	const float locomotionAnimatiomSmoothTime = .1f;
	
	NavMeshAgent agent;
	Animator anim;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float speedPercent = agent.velocity.magnitude / agent.speed;
		anim.SetFloat("speedPercent", speedPercent, locomotionAnimatiomSmoothTime, Time.deltaTime);
	}
}
