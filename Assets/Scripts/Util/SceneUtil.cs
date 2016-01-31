using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class SceneUtil {
	const int _mainMenu = 0;
	public static bool IsMainMenu () {
		return SceneManager.GetActiveScene().buildIndex == _mainMenu;
	}

	public static void LoadNextScene () {
		if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCount) {

			SceneManager.LoadScene (
				_mainMenu
			);

		} else {

			SceneManager.LoadScene (
				SceneManager.GetActiveScene().buildIndex + 1
			);

		}
	}
}
