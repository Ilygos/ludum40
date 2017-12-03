using UnityEngine;
using System;

public class Health : MonoBehaviour {

	public int HEALTH_POINT = 2;
	public event Action OnDead;

	void OnCollisionEnter(Collision collision) {
		GiveDamage bullet = collision.gameObject.GetComponent<GiveDamage>();

		if (bullet) {
            Debug.Log(gameObject.name + " " + HEALTH_POINT );
            HEALTH_POINT -= bullet.GetDamage();

			if (HEALTH_POINT <= 0) {
				if (gameObject.tag == "Player") {
					UIManager.Instance.loose();
				} else { 
					DestroyObject(gameObject);
				}

				if (OnDead != null) {
					OnDead.Invoke();
				}
			}
		}
	}

}
