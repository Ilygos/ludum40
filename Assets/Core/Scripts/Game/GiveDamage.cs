using UnityEngine;

public class GiveDamage : MonoBehaviour {
    [SerializeField]
    bool piercingDamage = false;
    [SerializeField]
    int DAMAGE = 1;

	public int GetDamage() {
        if (!piercingDamage) DestroyObject(gameObject);
		return DAMAGE;
	}

}
