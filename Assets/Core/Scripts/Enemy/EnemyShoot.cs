﻿using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	public float shootDelay = 1;
	public GameObject bulletPrefab;
	public Transform anchorGun;
	public bool targetPlayer;
    public AudioClip enemyShootSound;
    public AudioSource enemyGunAudioSource;

    Transform bulletsHolder;
	Transform player;
	Vector3 initialPosition;
    


	void Start () {
		player = GameObject.Find("/Environment/Actors/Player").transform;
		bulletsHolder = GameObject.Find("/Environment/BulletsHolder").transform;
		initialPosition = transform.position;

		StartCoroutine(ShootCoroutine()); 
	}

	void LateUpdate() {
		transform.SetY(initialPosition.y);
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

        if (enemyShootSound != null && enemyGunAudioSource != null)
        {
            enemyGunAudioSource.clip = enemyShootSound;
            enemyGunAudioSource.Play();
        }
		Instantiate(bulletPrefab, anchorGun.position, rotation, bulletsHolder);
	}
}
