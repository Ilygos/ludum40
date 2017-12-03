using UnityEngine;

public class Aim : MonoBehaviour {

	public LayerMask layerMask;
	public Transform player;
	public Transform SpriteHolder;

	void Update () {
		Vector3 position;

		if (MouseHelper.GetMousePositionInWorld(out position, layerMask)) {
			Debug.Log("pos: " + position + ", position: " + position);

			Vector3 relativePos = position - player.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);

			Debug.Log("relativePos" + relativePos);

			SpriteHolder.rotation = rotation;
		}
	}
}
