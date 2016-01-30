using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {
	const string PATH = "Audio";
	AudioList _fileList;
	AudioLoader _loader;

	Dictionary<int, AudioSource> _channels = new Dictionary<int, AudioSource>();
	Dictionary<string, AudioFile> _files = new Dictionary<string, AudioFile>();

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
		_fileList = _loader.Load();
		Debug.Log(_fileList[0]);
		Debug.Log(_fileList.Length);
	}

	void subscribeEvents () {
		EventController.OnNamedEvent += handleEvent;
	}

	void unsubscribeEvents () {
		EventController.OnNamedEvent -= handleEvent;
	}

	void handleEvent (string eventName) {

	}
}
