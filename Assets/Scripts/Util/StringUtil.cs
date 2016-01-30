using UnityEngine;
using System.Collections;

public static class StringUtil {

	public static bool [] StringComparison (string string1, string string2) {
		if (string1.Length != string2.Length) {
			throw new System.InvalidOperationException();
		}
		bool[] comparison = new bool[string1.Length];

		for (int i = 0; i < string1.Length; i++) {
			comparison[i] = string1[i] == string2[i];
		}

		return comparison;
	}


}
