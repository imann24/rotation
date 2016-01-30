using UnityEngine;
using System.Collections;

[System.Serializable]
public class AudioList {
	public AudioFile[] Audio;

	public AudioFile this[int index] {
		get {
			return Audio[index];
		}
	}

	public int Length {
		get {
			return Audio.Length;
		}
	}
}
