using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {
	public float distance;
	public int idleIntervalFrames;
	private float speeed = 1/360f;
	private int elapsedFrames = 0;
	private Vector3 initialPosition;
	private Vector3 goalPosition;
	void Start () {
		initialPosition = transform.position;
		goalPosition = initialPosition + transform.forward.normalized*distance;
	}	
	void Update () {
	    Animator anim = GetComponent<Animator>();
		if (anim.GetBool("isWalking")){
			float dot = Vector3.Dot(transform.forward.normalized, transform.position - goalPosition);
			if (dot >= 0f){
		        anim.SetBool("isWalking", false);
				transform.position = goalPosition;
				transform.Rotate(0, 180, 0);
				initialPosition = transform.position;
				goalPosition = initialPosition + transform.forward.normalized*distance;
			}
			else {
				transform.position += transform.forward.normalized*speeed*Time.deltaTime;
			}
		}
		else {
			++elapsedFrames;
			if (elapsedFrames >= idleIntervalFrames){
				elapsedFrames = 0;
				anim.SetBool("isWalking", true);
			}
		}
	}
}
