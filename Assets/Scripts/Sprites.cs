using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprites : MonoBehaviour {

	public Sprite[] Collection;
	private SpriteRenderer Renderer;
	private int Current;

	private void Start() {
		Renderer = GetComponent<SpriteRenderer>();
		InsertSprite(0, Renderer.sprite);
		Renderer.sprite = Collection[0];
	}

	public void SetSprite(int index) {
		Current = index % Collection.Length;
		Renderer.sprite = Collection[Current];
	}

	public void NextSprite() {
		SetSprite(Current + 1);
	}

	public void FirstSprite() {
		SetSprite(0);
	}

	public void LastSprite() {
		SetSprite(Collection.Length - 1);
	}

	public void InsertSprite(int index, Sprite sprite) {
		var tmp = new List<Sprite>(Collection);
		tmp.Insert(index, sprite);
		Collection = tmp.ToArray();
	}

	public void AppendSprite(Sprite sprite) {
		InsertSprite(Collection.Length, sprite);
	}

	public bool IsFirst() {
		return (Current == 0);
	}
}
