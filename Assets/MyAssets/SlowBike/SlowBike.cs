using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBike : MonoBehaviour {
	public float speed;
	public float firstRotationDistance;
	public float secondRotationDistance;
	public float returningDistance;
	private int elapsedFrame;
	private bool isFirstLine = true;
	private bool isSecondLine = false;
	private Vector3 initialPosition;
	private Quaternion initialRotaion;
	void Start () {
		initialPosition = transform.position;
		initialRotaion = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		++elapsedFrame;
		if(isFirstLine && elapsedFrame*speed >= firstRotationDistance){
			transform.Rotate(new Vector3(0, -19, 0));
			isFirstLine = false;
			isSecondLine = true;
		}
		else if(isSecondLine && elapsedFrame*speed >= secondRotationDistance){
			transform.Rotate(new Vector3(0, -71, 0));
			isSecondLine = false;
		}
		else if(elapsedFrame*speed >= returningDistance)
		{
			isFirstLine = true;
			elapsedFrame = 0;
			transform.rotation = initialRotaion;
			transform.position = initialPosition;
		}
		transform.position += transform.forward.normalized*speed;
	}
}
