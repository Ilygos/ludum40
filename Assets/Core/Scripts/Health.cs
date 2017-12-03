using UnityEngine;

public class Health : MonoBehaviour {

	public int healtPoints = 2;

	void OnCollisionEnter(Collision collision) {
		GiveDamage bullet = collision.gameObject.GetComponent<GiveDamage>();

		Debug.Log("collision");

		if (bullet) {
			healtPoints -= bullet.GetDamage();

			Debug.Log("healtPoints: " + healtPoints);

			if (healtPoints <= 0) {
                UIManager.Instance.loose();
			}
		}
	}

}
