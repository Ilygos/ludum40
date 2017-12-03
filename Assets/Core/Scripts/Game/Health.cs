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

		if (bullet && !_isDead) {
			Debug.Log(gameObject.name + " " + HEALTH_POINT);
			HEALTH_POINT -= bullet.GetDamage();

			if (HEALTH_POINT <= 0) {
				GetComponent<Animator>().SetBool("death", true);
				_audio.clip = deathSound;
				_audio.Play();

				if (OnDead != null) {
					OnDead.Invoke();
					kill();
				}
			}
		}
	}

}
