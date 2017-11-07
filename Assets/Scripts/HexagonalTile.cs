using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonalTile : MonoBehaviour {
	public TextMesh Text;
	public Vector2 Coordinates;
	public Vector2 Circle;

	private void Update() {
		if (Text) {
			Text.text = Circle.x + "," + Circle.y;
		}
	}
}
