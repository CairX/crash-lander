using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonalCoordinates : MonoBehaviour {

	[Header("Tile")]
	public float TileWidth;
	public float TileHeight;

	private static readonly Vector2[] Directions = new Vector2[] {
		new Vector2(1, 0),
		new Vector2(0, 1),
		new Vector2(-1, 1),
		new Vector2(-1, 0),
		new Vector2(0, -1),
		new Vector2(1, -1)
	};

	private Vector2 Translate(Vector2 position) {
		var x = position.x;
		var y = position.y;

		// Add tile size.
		x *= TileWidth;
		y *= TileHeight * 0.75f;

		// Shift from standard grid to hexagon.
		x += TileWidth * position.y * 0.5f;

		return new Vector2(x, y);
	}

	private void GenerateCircle(uint circle) {
	}

	public List<HexagonalTile> GetCircle(int circle) {
		var tiles = new List<HexagonalTile>();
		return tiles;
	}
}
