using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour {

	public Sprite Ship;
	public Sprite Standard;
	public Sprite A;
	public Sprite B;
	private HexagonalMap Map;

	private void Start () {
		Map = GetComponent<HexagonalMap>();
		Map.GetCircle(0)[0].GetComponent<Sprites>().ReplaceSprite(0, Standard);

		var amount = (int)(Map.Count * 0.05f);
		var exclude = new HashSet<Vector2>(new Vector2[] { Vector2.zero });

		var a = Map.GetRandomLocations(amount, exclude);
		exclude.UnionWith(a);

		var b = Map.GetRandomLocations(amount, exclude);
		exclude.UnionWith(b);

		foreach (var tile in Map.GetTiles()) {
			var sprites = tile.gameObject.GetComponent<Sprites>();
			sprites.AppendSprite(Standard);

			if (a.Contains(tile.Circle)) {
				sprites.InsertSprite(1, A);
				sprites.InsertSprite(2, B);
			} else if (b.Contains(tile.Circle)) {
				sprites.InsertSprite(1, B);
				sprites.InsertSprite(2, A);
			} else {
				sprites.AppendSprite(A);
				sprites.AppendSprite(B);
			}
		}
	}
}
