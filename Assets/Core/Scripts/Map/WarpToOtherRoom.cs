using UnityEngine;

public class WarpToOtherRoom : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log("OnTriggerEnter");

		if (other.gameObject.GetComponent<PlayerInput>()) {
			Debug.Log("player");
		}
	}

}
