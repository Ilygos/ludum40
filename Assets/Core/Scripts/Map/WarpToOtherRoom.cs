using UnityEngine;

public class WarpToOtherRoom : MonoBehaviour {

	RoomManager roomManager;

	void Start() {
		roomManager = GameObject.Find("/Environment/Rooms").GetComponent<RoomManager>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<PlayerInput>()) {
			Debug.Log("player");

			roomManager.GoToNext();
		}
	}

}
