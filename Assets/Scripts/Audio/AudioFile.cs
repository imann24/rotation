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
	public string[] StopEventNames;
	public bool Loop;
	public string Type;
	public int Channel;


	public override string ToString () {
		return string.Format (
			"[AudioFile:\n"+
			"FileName={0}\n" +
			"EventNames={1}\n" +
			"EndEventNames={2}\n" +
			"Loop={3}\n" +
			"Type={4}\n" +
			"Channel={5}" +
			"]", 
			FileName, 
			ArrayUtil.ToString(EventNames),
			ArrayUtil.ToString(StopEventNames),
			Loop, 
			Type, 
			Channel);
	}

	public bool HasEvent (string eventName) {
		return ArrayUtil.Contains (
			EventNames,
			eventName
		);
	}

	public bool HasEndEvent (string eventName) {
		return ArrayUtil.Contains (
			StopEventNames,
			eventName
		);
	}
}
