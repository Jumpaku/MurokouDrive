using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalDetecter : MonoBehaviour {
	public enum State { First, Second, Remainder, Fine, };
	private State state = State.First;
	private int penalty = 0;
	void Start () {}
	void Update () {}
	void OnTriggerEnter(Collider collider) {
		bool isGoal = false;
		string checkPoint = collider.tag;
		if (new ArrayList{"Start", "Middle", "Goal"}.Contains(checkPoint)) {
			switch (state){
			case State.First:
				if (checkPoint == "Middle" && penalty == 0){
					state = State.Second;
				}
				else if (checkPoint == "Middle" && penalty > 0) {
					state = State.Second;
					--penalty;
				}
				else if (checkPoint == "Start") {
					state = State.Remainder;
					++penalty;
				}
				break;
			case State.Second:
				if (checkPoint == "Goal" && penalty == 0) {
					state = State.Fine;
					isGoal = true;
				}
				else if (checkPoint == "Goal" && penalty > 0){
					state = State.Remainder;
					--penalty;
				}
				else if (checkPoint == "Middle"){
					state = State.First;
					++penalty;
				}
				break;
			case State.Remainder:
				if (checkPoint == "Goal") {
					state = State.Second;
					++penalty;
				}
				else if (checkPoint == "Start") {
					state = State.First;
					--penalty;
				}
				break;
			}
		}
		if(isGoal){
			SceneManager.LoadScene("ClearScene");
		}
	}
}
