using UnityEngine;
using System;

public class Health : MonoBehaviour {

    public int HEALTH_POINT = 2;
    public AudioClip deathSound;
    public event Action OnDead;
    [HideInInspector]
    public bool _isDead = false;
    AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {

    }

    public void kill()
    {
        DestroyObject(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
		GiveDamage bullet = collision.gameObject.GetComponent<GiveDamage>();

		if (bullet) {
            Debug.Log(gameObject.name + " " + HEALTH_POINT );
            HEALTH_POINT -= bullet.GetDamage();

			if (HEALTH_POINT <= 0) {
                _audio.clip = deathSound;
                _audio.Play();
                GetComponent<Animator>().SetBool("death", true);
				if (gameObject.tag == "Player") {
					UIManager.Instance.loose();
				}

				if (OnDead != null) {
					OnDead.Invoke();
                    kill();
				}
			}
		}
	}

}
