using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CourseOutDetecter : MonoBehaviour {
	void Start () {}
	void Update () {}
    void OnCollisionEnter(Collision collision){
		Debug.Log(collision.collider.tag);
		if(collision.collider.CompareTag("CourseOut")){
			SceneManager.LoadScene("GameOverScene");
		}
	}
}
