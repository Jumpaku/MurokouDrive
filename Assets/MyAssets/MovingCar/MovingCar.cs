using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCar : MonoBehaviour {
	public float normalizedTime;

	void Start () {	
		GetComponent<Animator>().Play("Moving", -1, normalizedTime);
	}
	
	// Update is called once per frame
	void Update () {}
}
