using UnityEngine;
using System;

public class Health : MonoBehaviour {

	public int HEALTH_POINT = 2;
	public AudioClip deathSound;

	public event Action OnDead;

	AudioSource _audio;

	private void Start() {
		_audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision collision) {
		GiveDamage bullet = collision.gameObject.GetComponent<GiveDamage>();

		if (bullet) {
			Debug.Log(gameObject.name + " " + HEALTH_POINT);
			HEALTH_POINT -= bullet.GetDamage();

			if (HEALTH_POINT <= 0) {
				_audio.clip = deathSound;
				_audio.Play();

				if (OnDead != null) {
					OnDead.Invoke();
				}

				if (gameObject.tag == "Player") {
					UIManager.Instance.loose();
				} else {
					DestroyObject(gameObject);
				}
			}
		}
	}

}
