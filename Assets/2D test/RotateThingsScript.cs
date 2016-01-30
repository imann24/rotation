using UnityEngine;
using System.Collections;

public class RotateThingsScript : MonoBehaviour {
	public GameObject level;
	public GameObject player;

	public float rotateSpeed = 90f;
	private PlayerMovement2D p_movement;

	private bool rotating = false;
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
					p_movement.frozen = false;
					p_movement.DisableColliders (true);
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
	IEnumerator RotateClockwise(GameObject target){
		if(target == null){
			Debug.LogError("target game object is null");
			yield return null;
		}
		rotating = true;

		float endRotation = Mathf.Repeat(target.transform.localEulerAngles.z - rotateSpeed, 360f);

		float rotationDoneSoFar = 0.0f;

		while (rotationDoneSoFar <= 90.0f){
			float rotateBy = Time.deltaTime * 90.0f;
			target.transform.Rotate(Vector3.forward, -rotateBy);
			rotationDoneSoFar += rotateBy;
			yield return null;
		}
		target.transform.rotation = Quaternion.Euler(new Vector3(0, 0, endRotation));
		rotating = false;
	}

		
	IEnumerator RotateCounterClockwise(GameObject target){
		if (target == null) {
			Debug.LogError ("target game object is null");
			yield return null;
		}
		rotating = true;

		float endRotation = Mathf.Repeat (target.transform.localEulerAngles.z + rotateSpeed, 360f);

		float rotationDoneSoFar = 0.0f;

		while (rotationDoneSoFar <= 90.0f) {
			float rotateBy = Time.deltaTime * 90.0f;
			target.transform.Rotate (Vector3.forward, rotateBy);
			rotationDoneSoFar += rotateBy;
			yield return null;
		}

		target.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, endRotation));
		rotating = false;
	}
}
