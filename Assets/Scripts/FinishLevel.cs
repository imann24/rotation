using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
		SceneUtil.LoadNextScene();
    }
}
