using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour {

	public Sprite[] Collection;
	private Image Renderer;
	private int Current;

	private void Start() {
		Renderer = GetComponent<Image>();
		InsertSprite(0, Renderer.sprite);
		Renderer.sprite = Collection[0];
	}

	public void NextSprite() {
		Current = ((Current + 1) % Collection.Length);
		Renderer.sprite = Collection[Current];
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
