using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonalMap : MonoBehaviour {

	[Header("Map")]
	public int Radius;
	public bool Fill = true;

	[Header("Tile")]
	public GameObject Template;
	public float TileWidth;
	public float TileHeight;

	private List<HexagonalTile> Tiles = new List<HexagonalTile>();

	public static readonly Vector2[] Directions = new Vector2[] {
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
			for (int circle = 0; circle < Radius; circle++) {
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

		var hexa = center.GetComponent<HexagonalTile>();
		hexa.Coordinates = Vector2.zero;
		hexa.Circle = Vector2.zero;

		Tiles.Add(hexa);
	}

	private void GenerateCircle(int circle) {
		if (circle == 0) {
			GenerateCenter();
			return;
		}

		for (var edge = 0; edge < Directions.Length; edge++) {
			var offset = Directions[(edge + 2) % Directions.Length];

			for (var i = 0; i < circle; i++) {
				var tile = Instantiate(Template);
				var hexa = tile.GetComponent<HexagonalTile>();
				hexa.Coordinates = Directions[edge] * circle + offset * i;
				hexa.Circle = new Vector2(circle, edge * circle + i);

				var position = Translate(hexa.Coordinates);
				tile.transform.position = new Vector3(position.x, position.y, Template.transform.position.z);

				Tiles.Add(hexa);
			}
		}
	}

	public List<HexagonalTile> GetCircle(int circle) {
		var tiles = new List<HexagonalTile>();
		foreach (var tile in Tiles) {
			if (tile.Circle.x == circle) {
				tiles.Add(tile);
			}
			if (tiles.Count == (Directions.Length * circle * circle)) { break; }
		}
		return tiles;
	}

	public List<HexagonalTile> GetTiles() {
		return Tiles;
	}

	public int Count {
		get { return Tiles.Count; }
		private set { }
	}

	public HashSet<Vector2> GetRandomLocations(int amount, HashSet<Vector2> exclude) {
		HashSet<Vector2> locations = new HashSet<Vector2>();

		int i = 0;
		while (i < amount) {
			var circleX = Random.Range(0, Radius);
			var circleY = Random.Range(0, circleX * Directions.Length);
			var circle = new Vector2(circleX, circleY);
			if (!locations.Contains(circle) && !exclude.Contains(circle)) {
				locations.Add(circle);
				i++;
			}
		}

		return locations;
	}

	public void Reveal() {
		foreach (var tile in Tiles) {
			var sprites = tile.GetComponent<Sprites>();
			if (sprites.IsFirst()) {
				sprites.NextSprite();
			}
		}
	}
	public void Hide() {
		foreach (var tile in Tiles) {
			tile.GetComponent<Sprites>().FirstSprite();
		}
	}
}
