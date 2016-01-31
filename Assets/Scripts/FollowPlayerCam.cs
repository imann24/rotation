using UnityEngine;
using System.Collections;

public class FollowPlayerCam : MonoBehaviour {
	public GameObject player;
	public float vertical;
	public float zoomSize;
	public float zoomTime;
	public bool zooming = false;
	public bool following = true;

	private Camera cam;
	private float originalSize;

	void Start(){
		cam = GetComponent<Camera> ();
		originalSize = cam.transform.position.z;
		Zoom ();
	}
	// Update is called once per frame
	void LateUpdate () {
		if (following) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + vertical, -11f);
		}
	}
	public void Zoom(){
		if (!zooming) {
			CamZoom ();
		}
	}
	IEnumerator MoveTowards(Vector3 whereTo){
		float complete = 0f;
		Vector3 start = transform.position;
		Vector3 end = whereTo;
		float moveTime = 1f; //movein speed
		bool toFollow = false;
		if (!following) {
			moveTime = 0.5f; //moveout speed
			toFollow = true;
		}
		following = false;
		while (complete <= 1f) {
			complete += Time.deltaTime / moveTime;
			transform.position = Vector3.Lerp (start, end, complete);
			yield return null;
		}
		if (toFollow) {
			following = true;
		}
		zooming = false;
	}

	void CamZoom(){
		zooming = true;
		if (cam.transform.position.z >= zoomSize) {
			StopCoroutine ("MoveTowards");
			StartCoroutine ("MoveTowards" , new Vector3(9.9f, 12f, -26.9f));
		} else if (cam.transform.position.z <= originalSize) {
			StopCoroutine ("MoveTowards");
			StartCoroutine ("MoveTowards" , new Vector3 (player.transform.position.x, player.transform.position.y + vertical, zoomSize));
		}
	}

}
