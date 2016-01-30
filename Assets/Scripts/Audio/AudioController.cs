using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {
	const string PATH = "Audio";
	AudioList _fileList;
	AudioLoader _loader;

	Dictionary<int, AudioSource> _channels = new Dictionary<int, AudioSource>();
	Dictionary<string, AudioFile> _files = new Dictionary<string, AudioFile>();

	Dictionary<string, List<AudioFile>> _playEvents = new Dictionary<string, List<AudioFile>>();
	Dictionary<string, List<AudioFile>> _stopEvents = new Dictionary<string, List<AudioFile>>();
	void Awake () {
		init();
		subscribeEvents();
	}

	// Use this for initialization
	void Start () {
		PlayMusic();
	}

	void OnDestroy () {
		unsubscribeEvents();
	}

	public void PlayMusic () {
		EventController.Event("music");
	}

	public void StopMusic () {
		EventController.Event("stopMusic");
	}

	public void Play (AudioFile file) {
		AudioSource source = getChannel(file.Channel);

		source.clip = file.Clip;

		source.loop = file.Loop;

		source.Play();

	}

	public void Stop (AudioFile file) {

		if (channelExists(file.Channel)) {
			AudioSource source = getChannel(file.Channel);

			if (source.clip == _channels[file.Channel]) {

				source.Stop();

			}
		}

	}

	bool channelExists (int channelNumber) {
		return _channels.ContainsKey(channelNumber);
	}
	AudioSource getChannel (int channelNumber) {
		if (_channels.ContainsKey(channelNumber)) {
		
			return _channels[channelNumber];

		} else {

			AudioSource newSource = gameObject.AddComponent<AudioSource>();
			_channels.Add(channelNumber, newSource);
			return newSource;

		}
	}


	void init () {
		_loader = new AudioLoader(PATH);
		_fileList = _loader.Load();

		initFileDictionary(_fileList);

		addAudioEvents();
	}

	void initFileDictionary (AudioList audioFiles) {
		for (int i = 0; i < audioFiles.Length; i++) {
			_files.Add (
				audioFiles[i].FileName,
				audioFiles[i]
			);
		}
	}

	void addAudioEvents () {

		for (int i = 0; i < _fileList.Length; i++) {

			addPlayEvents(_fileList[i]);
			addStopEvents(_fileList[i]);

		}

	}

	void addPlayEvents (AudioFile file) {
		
		for (int j = 0; j < file.EventNames.Length; j++) {

			if (_playEvents.ContainsKey(file.EventNames[j])) {

				_playEvents[file.EventNames[j]].Add(file);

			} else {

				List<AudioFile> files = new List<AudioFile>();
				files.Add(file);

				_playEvents.Add (
					file.EventNames[j],
					files
				);

			}

		}

	}

	void addStopEvents (AudioFile file) {

		for (int j = 0; j < file.StopEventNames.Length; j++) {

			if (_stopEvents.ContainsKey(file.EventNames[j])) {

				_stopEvents[file.EventNames[j]].Add(file);

			} else {

				List<AudioFile> files = new List<AudioFile>();
				files.Add(file);

				_stopEvents.Add (
					file.EventNames[j],
					files
				);

			}

		}

	}
	void subscribeEvents () {
		EventController.OnNamedEvent += handleEvent;
	}

	void unsubscribeEvents () {
		EventController.OnNamedEvent -= handleEvent;
	}

	void handleEvent (string eventName) {

		if (_playEvents.ContainsKey(eventName)) {
			playAudioList(
				_playEvents[eventName]
			);
		}

		if (_stopEvents.ContainsKey(eventName)) {
			stopAudioList(
				_stopEvents[eventName]
			);
		}
				
	}

	void playAudioList (List<AudioFile> files) {
		for (int i = 0; i < files.Count; i++) {
			Play(files[i]);
		}
	}

	void stopAudioList (List<AudioFile> files) {
		for (int i = 0; i < files.Count; i++) {
			Stop(files[i]);
		}
	}
}
