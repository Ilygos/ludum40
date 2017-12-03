using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public float speed = 1f;
	public float destroyTime = 3f;

	Rigidbody rbody;

	void Start () {
		rbody = GetComponent<Rigidbody>();
		rbody.velocity = transform.forward * speed;
		Destroy(gameObject, destroyTime);
	}

	void LateUpdate() {
		rbody.velocity = speed * rbody.velocity.normalized;
	}

}
