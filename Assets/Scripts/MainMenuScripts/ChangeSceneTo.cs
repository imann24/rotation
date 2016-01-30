using UnityEngine;
using System.Collections;

public class ChangeSceneTo : MonoBehaviour {
	
	public void ChangeToScene (string sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);
	}
}
