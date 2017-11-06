using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

	public Sprite[] Sprites;
	private SpriteRenderer Renderer;
	private int Current;

	private void Start() {
		Renderer = GetComponent<SpriteRenderer>();
		InsertSprite(0, Renderer.sprite);
		Renderer.sprite = Sprites[0];
	}

	public void NextSprite() {
		Current = ((Current + 1) % Sprites.Length);
		Renderer.sprite = Sprites[Current];
	}

	public void InsertSprite(int index, Sprite sprite) {
		var tmp = new List<Sprite>(Sprites);
		tmp.Insert(index, sprite);
		Sprites = tmp.ToArray();
	}

	public void AppendSprite(Sprite sprite) {
		InsertSprite(Sprites.Length, sprite);
	}
}
