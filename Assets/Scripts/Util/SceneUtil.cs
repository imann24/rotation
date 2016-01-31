using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class SceneUtil {

	public static bool IsMainMenu () {
		return SceneManager.GetActiveScene().buildIndex == 0;
	}
}
