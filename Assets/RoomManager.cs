using UnityEngine;

public class RoomManager : MonoBehaviour {

	public GameObject[] rooms;

	int currentRoom = 0;

	void Start () {
		
	}
	
	public void GoToNext() {
		currentRoom++;

		if (currentRoom >= rooms.Length) {
			Debug.Log("You Win");
		} else {
			Debug.Log("Go to next room");

			GameObject nextRoom = rooms[currentRoom];
//			Transform playerSpawn = 
		}
	}
}
