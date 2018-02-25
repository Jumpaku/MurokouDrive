using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonListeners : MonoBehaviour {
	void Start () {
	}
	void Update () {
	}

	public void GoToTitleScene(){
		SceneManager.LoadScene("TitleScene");
	}
	public void GoToGameOverScene(){
		SceneManager.LoadScene("GameOverScene");
	}
	public void GoToGameScene(){
		SceneManager.LoadScene("GameScene");
	}
	public void GoToClearScene(){
		SceneManager.LoadScene("ClearScene");
	}
	public void QuitGame(){
		Application.Quit();
	}
}
