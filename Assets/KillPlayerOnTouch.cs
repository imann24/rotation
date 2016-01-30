using UnityEngine;
using System.Collections;

public class KillPlayerOnTouch : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
        }

    }
}
