using UnityEngine;

public class Aim : MonoBehaviour {

	public LayerMask layerMask;
	public Transform player;
	public Transform SpriteHolder;

	Quaternion rotation;
	public Quaternion Rotation { get { return rotation; } }

	void Update () {
		Vector3 position;

		//		Vector2 inputAxis = input.aimAxis;

		//		if (inputAxis.magnitude > deadzone) {
		//			axis = inputAxis;
		//		}

		if (MouseHelper.GetMousePositionInWorld(out position, layerMask)) {
			Vector3 relativePos = position - player.position;
			rotation = Quaternion.LookRotation(relativePos);

			SpriteHolder.rotation = rotation;
		}
	}
}
