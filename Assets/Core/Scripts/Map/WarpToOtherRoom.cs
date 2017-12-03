using UnityEngine;
using System.Collections;

public class WarpToOtherRoom : MonoBehaviour {

	public AnimationCurve curve;
	public float duration = 1.0f;

	Transform player;

	void Start() {
		player = GameObject.Find("/Environment/Actors/Player").transform;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<PlayerInput>()) {
			Debug.Log("player");

			StartCoroutine(RoomTransition());
		}
	}

	IEnumerator RoomTransition() {
		player.transform.SetZ(20f);

		Debug.Log("MoveCamera");
		Transform cameraTransform = Camera.main.transform;
		Vector3 startPosition = cameraTransform.position;
		Vector3 endPosition = new Vector3(
			startPosition.x,
			startPosition.y,
			startPosition.z + 20f
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
