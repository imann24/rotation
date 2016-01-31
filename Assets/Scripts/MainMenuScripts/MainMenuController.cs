using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	public Text LevelName;

	int _levelToLoad = 1;

	string [] _levelNames = {
		"Main Menu",
		"Level 1",
		"Level 2",
		"Level 3",
		"Level 4",
		"Level 5",
		"Level 6"
	};

	// Use this for initialization
	void Start () {
		EventController.Event("menuMusic");
	}

	public void SetLevel (int levelNumber) {
		setLevelName(_levelNames[levelNumber]);
		_levelToLoad = levelNumber;
	}

	public void LoadLevel () {
		LoadLevel(_levelToLoad);
	}

	public void LoadLevel (int levelNumber) {
		SceneManager.LoadScene(levelNumber);
	}

	void setLevelName (string levelName) {
		LevelName.text = levelName;
	}
}
