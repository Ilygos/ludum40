using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	public float shootDelay = 1;
	public GameObject bulletPrefab;
	public Transform anchorGun;

	Transform bulletsHolder;
	Transform player;

	void Start () {
		player = GameObject.Find("/Environment/Actors/Player").transform;
		bulletsHolder = GameObject.Find("/Environment/BulletsHolder").transform;

		StartCoroutine(ShootCoroutine()); 
	}
	
	void Update () {
		
	}

	IEnumerator ShootCoroutine() {
		while(true) { 
			yield return new WaitForSeconds(shootDelay);

			Shoot();
		}
	}

	void Shoot() {
		Instantiate(bulletPrefab, anchorGun.position, anchorGun.rotation, bulletsHolder);
	}
}
