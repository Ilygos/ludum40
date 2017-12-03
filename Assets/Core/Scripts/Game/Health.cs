using UnityEngine;
using System;

public class Health : MonoBehaviour {

	public int HEALTH_POINT = 2;
	public AudioClip deathSound;

	public event Action OnDead;

	[HideInInspector]
	public bool _isDead = false;
	AudioSource _audio;

	public void kill() {
		// ToDo: 
		DestroyObject(gameObject);
	}

	private void Start() {
		_audio = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision collision) {
		GiveDamage bullet = collision.gameObject.GetComponent<GiveDamage>();

		if (bullet == null) {
			return;
		}

		bool isPlayer = GetComponent<PlayerInput>();

		HEALTH_POINT -= bullet.GetDamage();
		Debug.Log(gameObject.name + " " + HEALTH_POINT);

		if (HEALTH_POINT <= 0) {
			if (_audio != null) {
				_audio.clip = deathSound;
				_audio.Play();
			}

			Debug.Log("isPlayer: " + isPlayer);

			if (isPlayer) {
				GetComponent<Animator>().SetBool("death", true);
				UIManager.Instance.loose();
			} else { // is monster
				if (OnDead != null) {
					Debug.Log("OnDead");
					OnDead.Invoke();
					kill();
				}
			}
		}
	}
}
