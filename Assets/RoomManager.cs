using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

	public GameObject[] rooms;
	public AnimationCurve curve;
	public float duration = 1.0f;

	int currentRoom = 0;

	void Start () {
		GoToRoom(false);
	}

	public void GoToNext(bool withCameraAnimation = true) {
		currentRoom++;
		GoToRoom(withCameraAnimation);
	}

	void GoToRoom(bool withCameraAnimation) {
		if (currentRoom >= rooms.Length) {
			Debug.Log("You Win");
		} else {
			Debug.Log("Go to next room");

			GameObject nextRoom = rooms[currentRoom];

			// Move player to new room
			Transform playerSpawn = nextRoom.transform.Find("Spawner/Player").transform;
			Transform player = GameObject.Find("/Environment/Actors/Player").transform;

			player.transform.position = playerSpawn.position;

			// Move camera to new map
			if (withCameraAnimation) {
				StartCoroutine(RoomTransition(nextRoom));
			} else {
				SimpleMoveCamera(nextRoom);
			}

			// Init the room
			nextRoom.GetComponent<RoomSetting>().Init();
		}
	}

	void SimpleMoveCamera(GameObject nextRoom) {
		Vector3 cameraPositionInRoom = nextRoom.transform.Find("CameraPosition").transform.position;
		Transform cameraTransform = Camera.main.transform;
		Vector3 cameraPos = cameraTransform.position;

		cameraTransform.position = new Vector3(
			cameraPositionInRoom.x,
			cameraPos.y,
			cameraPositionInRoom.z
		);
	}

	IEnumerator RoomTransition(GameObject nextRoom) {
		Debug.Log("MoveCamera");
		Transform cameraTransform = Camera.main.transform;
		Vector3 startPosition = cameraTransform.position;
		Vector3 cameraPositionInRoom = nextRoom.transform.Find("CameraPosition").transform.position;
		Vector3 cameraPos = cameraTransform.position;

		Vector3 endPosition = new Vector3(
			cameraPositionInRoom.x,
			cameraPos.y,
			cameraPositionInRoom.z
		);
		float t = 0f;

		while(cameraTransform.position != endPosition) {
			Debug.Log(".");
			t += Time.deltaTime;
			float s = t / duration;
			cameraTransform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(s));

			yield return null;
		}

		Debug.Log("end");
	}

}
