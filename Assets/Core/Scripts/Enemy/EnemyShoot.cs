using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	public float shootDelay = 1;
	public GameObject bulletPrefab;
	public Transform anchorGun;
	public bool targetPlayer;

	Transform bulletsHolder;
	Transform player;

	void Start () {
		player = GameObject.Find("/Environment/Actors/Player").transform;
		bulletsHolder = GameObject.Find("/Environment/BulletsHolder").transform;

		StartCoroutine(ShootCoroutine()); 
	}
	
	IEnumerator ShootCoroutine() {
		while(true) { 
			yield return new WaitForSeconds(shootDelay);

			Shoot();
		}
	}

	void Shoot() {
		Quaternion rotation;

		if (targetPlayer) {
			Vector3 relativePos = player.position - transform.position;
			rotation = Quaternion.LookRotation(relativePos);
		} else {
			rotation = anchorGun.rotation;
		}

		Instantiate(bulletPrefab, anchorGun.position, rotation, bulletsHolder);
	}
}
