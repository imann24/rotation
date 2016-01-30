using UnityEngine;
using System.Collections;

public static class VectorUtil  {

	public static bool ZeroVector (Vector2 vector) {
		return vector.x == 0 &&
			vector.y == 0;
	}
}
