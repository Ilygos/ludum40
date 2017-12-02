using UnityEngine;

public class MapImporter : MonoBehaviour {

	public GameObject mapToImport;

	public void Import() {
		Transform bouncingColliders = mapToImport.transform.Find("BouncingColliders");

		// Replace BoxCollider2D to Collider2D
		foreach (Transform colliderTransfrom in bouncingColliders) {
			var collider2d = colliderTransfrom.GetComponent<BoxCollider2D>();

			if (collider2d) {
				Vector2 offset = collider2d.offset;
				Vector2 size = collider2d.size;

				DestroyImmediate(collider2d);

				BoxCollider collider3d = colliderTransfrom.gameObject.AddComponent<BoxCollider>();

				collider3d.center = new Vector3(offset.x, offset.y, -0.5f);
				collider3d.size = new Vector3(size.x, size.y, 1);
			}
		}

		// Rotate map to be in x, z plan
		mapToImport.transform.rotation = Quaternion.Euler(90f, 0, 0);
	}

}
