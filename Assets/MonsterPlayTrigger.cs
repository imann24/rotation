using UnityEngine;
using System.Collections;

public class MonsterPlayTrigger : MonoBehaviour {
	public GameObject monster;
	public GameObject player;

	private bool hit = false;
	void OnTriggerEnter2D (Collider2D other){
		if (!hit) {
			if (other.gameObject.tag == "Player") {

				Debug.Log ("hit");
				monster.GetComponent<Animator> ().SetTrigger ("Play");
				Camera.main.GetComponent<FollowPlayerCam> ().Zoom ();

				Invoke ("EndGame", 3.0f);
				hit = true;
			}
		}
	}

	void EndGame(){
		SceneUtil.LoadMainMenu ();
	}
}
