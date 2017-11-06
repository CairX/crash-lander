using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour {

	public Sprite Ship;
	public Sprite Standard;
	private HexagonalMap Map;

	private void Start () {
		Map = GetComponent<HexagonalMap>();
		Map.GetCircle(0)[0].GetComponent<SpriteRenderer>().sprite = Ship;

		for (int circle = 1; circle < Map.Radius; circle++) {
			var tiles = Map.GetCircle(circle);
			foreach (var tile in tiles) {
				tile.gameObject.GetComponent<SpriteChanger>().AppendSprite(Standard);
			}
		}
	}
}
