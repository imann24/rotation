using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
	public Animator ScreenController;

	public void Pause () {
		openMenu();
		EventController.Event("pause");
	}

	public void Resume () {
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
