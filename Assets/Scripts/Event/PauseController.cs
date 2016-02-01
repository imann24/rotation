using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
	public Animator ScreenController;

	KeyCode _pauseKey = KeyCode.Escape;
	bool _paused = false;

	void Update () {
		if (Input.GetKeyDown(_pauseKey)) {
			
			if (_paused) {
				Resume();
			} else {
				Pause();
			}

		}
	}

	public void Pause () {
		_paused = true;
		openMenu();
		EventController.Event("pause");
	}

	public void Resume () {
		_paused = false;
		closeMenu();
		EventController.Event("resume");
	}

	public void GoToMainMenu () {
		SceneUtil.LoadMainMenu();
	}

	void closeMenu () {
		ScreenController.SetBool("isDisplayed", false);
	}

	void openMenu () {
		ScreenController.SetBool("isDisplayed", true);
	}
}
