using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonalMap : MonoBehaviour {

	[Header("Map")]
	public uint Radius;
	public bool Fill = true;

	[Header("Tile")]
	public GameObject Template;
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

	private void Start() {
		if (Fill && Radius > 0) {
			for (uint circle = 0; circle < Radius; circle++) {
				GenerateCircle(circle);
			}
		}
		else {
			GenerateCircle(Radius);
		}
	}

	private void GenerateCenter() {
		var center = Instantiate(Template);
		center.transform.position = new Vector3(0, 0, Template.transform.position.z);
	}

	private void GenerateCircle(uint circle) {
		if (circle == 0) {
			GenerateCenter();
			return;
		}

		for (var edge = 0; edge < 6; edge++) {
			var offset = Directions[(edge + 2) % Directions.Length];

			for (var i = 0; i < circle; i++) {
				var tile = Instantiate(Template);
				var position = Translate(Directions[edge] * circle + offset * i);
				tile.transform.position = new Vector3(position.x, position.y, Template.transform.position.z);
			}
		}
	}
}
