using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

    public DoorScript[] doors;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            foreach (DoorScript d in doors)
            {
                if(d == null)
                {
                    Debug.Log("There is a null door that this switch is operating");
                }
                d.flipOpenClose();
            }
        }

    }
}
