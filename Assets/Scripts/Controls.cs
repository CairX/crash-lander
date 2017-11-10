using UnityEngine;

public class Controls : MonoBehaviour {

	public Player[] Players;
	private Player ActivePlayer;

	private void Start () {
		ActivePlayer = Players[0];
	}

	public void SetPlayer(int index) {
		ActivePlayer = Players[index];
	}
	
	private void Update () {
		foreach (var player in Players) {
			if (Input.GetKeyUp(player.Key)) {
				ActivePlayer = player;
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			var hit = Physics2D.Raycast(point, Vector2.zero, 0f);
			if (hit) {
				var sprites = hit.transform.GetComponent<Sprites>();
				if (sprites.IsFirst()) {
					sprites.NextSprite();
				}
				ActivePlayer.Avatar.transform.position = point.ChangeZ(ActivePlayer.Avatar.transform.position.z);
			}
		}

		if (Input.GetMouseButtonDown(1)) {
			Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var hit = Physics2D.Raycast(point, Vector2.zero, 0f);
			if (hit) {
				hit.transform.GetComponent<Sprites>().NextSprite();
			}
		}
	}
}

[System.Serializable]
public class Player {
	public GameObject Avatar;
	public KeyCode Key;
}
