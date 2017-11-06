using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	public Player[] Players;
	private Player ActivePlayer;

	// Use this for initialization
	private void Start () {
		//ActivePlayer = Players[0];
	}
	
	// Update is called once per frame
	private void Update () {
		foreach (var player in Players) {
			if (Input.GetKeyUp(player.Key)) {
				ActivePlayer = player;
			}
		}

		if (Input.GetKeyUp(KeyCode.Alpha0)) {
			ActivePlayer = null;
		}

		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (ActivePlayer == null) {
				var hit = Physics2D.Raycast(point, Vector2.zero, 0f);
				if (hit) {
					hit.transform.GetComponent<SpriteChanger>().NextSprite();
				}
			} else {
				ActivePlayer.Avatar.transform.position = point.ChangeZ(ActivePlayer.Avatar.transform.position.z);
			}
		}
	}
}

[System.Serializable]
public class Player {
	public GameObject Avatar;
	public KeyCode Key;
}
