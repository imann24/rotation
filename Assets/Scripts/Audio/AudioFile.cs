using UnityEngine;
using System.Collections;

[System.Serializable]
public class AudioFile {
	AudioClip _clip;
	public AudioClip Clip {
		get {
			if (_clip == null) {
				_clip = AudioLoader.GetClip(FileName);
				Debug.Log(_clip);
			}

			return _clip;
		}
	}

	public string FileName;
	public string[] EventNames;
	public bool Loop;
	public string Type;
	public int Channel;


	public override string ToString () {
		return string.Format (
			"[AudioFile:\n"+
			"FileName={0}\n" +
			"EventNames={1}\n" +
			"Loop={2}\n" +
			"Type={3}\n" +
			"Channel={4}" +
			"]", 
			FileName, 
			EventNames, 
			Loop, 
			Type, 
			Channel);
	}
}
