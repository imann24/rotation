using UnityEngine;
using System.Collections;

[System.Serializable]
public class AudioFile {
	AudioClip _clip;
	public AudioClip Clip {
		get {
			if (_clip == null) {
				_clip = AudioLoader.GetClip(FileName);
			}

			return _clip;
		}
	}

	public string FileName;
	public string[] EventNames;
	public bool Loop;
	public string Type;
	public int Channel;

}
