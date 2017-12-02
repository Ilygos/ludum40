using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public float speed = 1f;
	public float destroyTime = 3f;

	Rigidbody rigidbody;

	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.velocity = transform.forward * speed;
		Destroy(gameObject, destroyTime);
	}

	void LateUpdate() {
		rigidbody.velocity = speed * rigidbody.velocity.normalized;
	}

}
