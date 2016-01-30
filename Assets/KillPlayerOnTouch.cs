using UnityEngine;
using System.Collections;

public class KillPlayerOnTouch : MonoBehaviour {

    public LevelManager levelManager;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            levelManager.RestartLevel();
			EventController.Event("death");
        }

    }
}
