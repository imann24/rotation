using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	const string PATH = "Audio";
	AudioList _files;
	AudioLoader _loader;

	void Awake () {
		init();
	}

	// Use this for initialization
	void Start () {
	
	}

	void addSource () {

	}

	// Update is called once per frame
	void Update () {
	
	}


	void init () {
		_loader = new AudioLoader(PATH);
		_files = _loader.Load();
		Debug.Log(_files[0]);
		Debug.Log(_files.Length);
	}
}
