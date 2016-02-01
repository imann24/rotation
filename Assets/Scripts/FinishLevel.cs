using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {
	private bool hit = false;
    void OnTriggerExit2D(Collider2D other)
    {
		if (!hit){
			if (SceneManager.GetActiveScene().buildIndex == 6){
				SceneManager.LoadScene(7);
			}else{
			SceneUtil.LoadNextScene();

			}
			hit = true;
		}
    }
}
