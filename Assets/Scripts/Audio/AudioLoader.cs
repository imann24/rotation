using UnityEngine;
using System.Collections;

public class AudioLoader {
	const string DIRECTORY = "Audio";
	string _path;

	public AudioLoader (string path) {
		this._path = path;
	}

	public AudioFile Load () {
		return JsonUtility.FromJson<AudioFile>(
			FileUtil.FileText (
				this._path
			)
		);
	}

	public AudioClip GetClip (AudioFile file) {
		return Resources.Load<AudioClip>(
			DIRECTORY + file.FileName
		);
	}

}
