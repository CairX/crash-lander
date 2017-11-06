using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
	public Player[] Players;
	private Player ActivePlayer;

	// Use this for initialization
	private void Start () {
		ActivePlayer = Players[0];
	}
	
	// Update is called once per frame
	private void Update () {
		foreach (var player in Players) {
			if (Input.GetKeyUp(player.Key)) {
				ActivePlayer = player;
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			/*var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var hit = Physics2D.Raycast(point, Vector2.zero, 0f);
			if (hit) {
				//hit.transform.GetComponent<Tile>().ChangeColor();
			}*/
			Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			ActivePlayer.Avatar.transform.position = point.ChangeZ(ActivePlayer.Avatar.transform.position.z);
		}
	}
}

[System.Serializable]
public class Player {
	public GameObject Avatar;
	public KeyCode Key;
}
