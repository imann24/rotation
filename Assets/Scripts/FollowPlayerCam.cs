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
		originalSize = cam.orthographicSize;
		Zoom ();
	}
	// Update is called once per frame
	void LateUpdate () {
		if (following) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + vertical, -15f);
		}
	}
	public void Zoom(){
		if (!zooming) {
			StopCoroutine ("CamZoom");
			StartCoroutine ("CamZoom");
		}
	}
	IEnumerator MoveTowards(Vector3 whereTo){
		float complete = 0f;
		Vector3 start = transform.position;
		Vector3 end = whereTo;
		float moveTime = 0.5f; //movein speed
		bool toFollow = false;
		if (!following) {
			moveTime = 0.05f; //moveout speed
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
	}

	IEnumerator CamZoom(){
		zooming = true;
		float percentComplete = 0;
		bool grow;
		if (cam.orthographicSize < originalSize - 0.01f) {
			grow = true;
			StopCoroutine ("MoveTowards");
			StartCoroutine ("MoveTowards" , new Vector3(9.9f, 12f, -15f));
		} else {
			grow = false;
			StopCoroutine ("MoveTowards");
			StartCoroutine ("MoveTowards" , new Vector3 (player.transform.position.x, player.transform.position.y + vertical, -15f));
		}
		while (percentComplete < 1.00f) {
			percentComplete += Time.deltaTime / zoomTime;

			// update the position based on our percentage complete
			if (grow) {
				cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, originalSize, percentComplete);
			} else {
				cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, zoomSize, percentComplete);
			}

			if(grow){
				if (cam.orthographicSize >= originalSize - 0.01f){
					percentComplete = 1.00f;
				}
			}else{
				if (cam.orthographicSize <= zoomSize + 0.01f ){
					percentComplete = 1.00f;
				}
			}
			// stop processing for now, and continue next frame
			yield return null;
		}
		zooming = false;
	}

}
