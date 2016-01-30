using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    public bool isDoorOpen;

    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = !isDoorOpen;
        gameObject.GetComponent<SpriteRenderer>().enabled = !isDoorOpen;
    }

	public void flipOpenClose()
    {
        if (isDoorOpen)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        isDoorOpen = !isDoorOpen;
    }
}
