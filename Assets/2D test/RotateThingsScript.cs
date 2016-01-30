using UnityEngine;
using System.Collections;

public class RotateThingsScript : MonoBehaviour {
	public GameObject level;
	public GameObject player;

	public float rotateSpeed = 90f;
	private PlayerMovement2D p_movement;

	private bool rotating = false;
	private float currentRotation = 0f;
	public bool frozen = false;
	// Use this for initialization
	void Start () {
		p_movement = player.GetComponent<PlayerMovement2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		
		if (Input.GetKeyDown(KeyCode.F)){
			if (!rotating) {
				if (!frozen) {
					if (p_movement.grounded) {
						p_movement.frozen = true;
						p_movement.DisableColliders (false);
					} else {
						return;
					}
				}
				if (frozen){
					StartCoroutine ("RotatePlayer");
				}
				frozen = !frozen;
			}
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			if (frozen) {
				if (!rotating) {
					StartCoroutine ("RotateCounterClockwise", level);
				}
			}
		}if (Input.GetKeyDown (KeyCode.E)) {
			if (frozen) {
				if (!rotating) {
					StartCoroutine ("RotateClockwise", level);
				}
			}
		}

	}
	IEnumerator RotatePlayer(){
		float amountToRotate = Mathf.Repeat(0 - (level.transform.eulerAngles.z - currentRotation), 360f);
		int dir;
		if (amountToRotate >= 180f) {
			dir = -1;
		} else {
			dir = 1;
		}
		float rotationDoneSoFar = 0.0f;

		while (rotationDoneSoFar <= amountToRotate){
			float rotateBy = Time.deltaTime * rotateSpeed;
			player.transform.Rotate(Vector3.forward, rotateBy * dir);
			rotationDoneSoFar += rotateBy;
			yield return null;
		}
		player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		p_movement.frozen = false;
		p_movement.DisableColliders (true);
		currentRotation = level.transform.eulerAngles.z;
	}

	IEnumerator RotateClockwise(GameObject target){
		EventController.Event("rotate");

		if(target == null){
			Debug.LogError("target game object is null");
			yield return null;
		}
		rotating = true;

		float endRotation = Mathf.Repeat(target.transform.localEulerAngles.z - 90f, 360f);

		float rotationDoneSoFar = 0.0f;

		while (rotationDoneSoFar <= 90.0f){
			float rotateBy = Time.deltaTime * rotateSpeed;
			target.transform.Rotate(Vector3.forward, -rotateBy);
			rotationDoneSoFar += rotateBy;
			yield return null;
		}
		target.transform.rotation = Quaternion.Euler(new Vector3(0, 0, endRotation));
		rotating = false;

		EventController.Event("endRotate");
	}

		
	IEnumerator RotateCounterClockwise(GameObject target){
		EventController.Event("rotate");

		if (target == null) {
			Debug.LogError ("target game object is null");
			yield return null;
		}
		rotating = true;

		float endRotation = Mathf.Repeat (target.transform.localEulerAngles.z + 90f, 360f);

		float rotationDoneSoFar = 0.0f;

		while (rotationDoneSoFar <= 90.0f) {
			float rotateBy = Time.deltaTime * rotateSpeed;
			target.transform.Rotate (Vector3.forward, rotateBy);
			rotationDoneSoFar += rotateBy;
			yield return null;
		}

		target.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, endRotation));
		rotating = false;

		EventController.Event("endRotate");
	}
}
