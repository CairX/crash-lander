using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour {

	public Sprite Ship;
	public Sprite Standard;
	public Sprite A;
	public Sprite B;
	private HexagonalMap Map;

	private void Start () {
		Map = GetComponent<HexagonalMap>();
		Map.GetCircle(0)[0].GetComponent<SpriteRenderer>().sprite = Standard;

		var amount = (int)(Map.Count * 0.05f);
		var a = Map.RandomizeLocation(amount, new HashSet<Vector2>());
		var b = Map.RandomizeLocation(amount, a);

		foreach (var pos in a) {
			var tile = Map.GetCircle(((int)pos.x))[((int)pos.y)];
			tile.gameObject.GetComponent<Sprites>().AppendSprite(A);
		}

		foreach (var pos in b) {
			var tile = Map.GetCircle(((int)pos.x))[((int)pos.y)];
			tile.gameObject.GetComponent<Sprites>().AppendSprite(B);
		}

		for (int circle = 1; circle < Map.Radius; circle++) {
			var tiles = Map.GetCircle(circle);
			foreach (var tile in tiles) {
				tile.gameObject.GetComponent<Sprites>().AppendSprite(Standard);
			}
		}

		Debug.Log(Map.Count);
		Debug.Log(amount);
	}
}
