using UnityEngine;
using System.Collections;

public class KillPlayerOnTouch : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
			EventController.Event("death");
            Destroy(coll.gameObject);
        }

    }
}
