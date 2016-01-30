using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	const string PATH = "Audio";
	AudioFile _audioFile;
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
		_audioFile = _loader.Load();
		Debug.Log(_audioFile);
	}
}
