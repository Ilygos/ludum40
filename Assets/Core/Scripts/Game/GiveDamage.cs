using UnityEngine;

public class GiveDamage : MonoBehaviour {

    [SerializeField]
    int DAMAGE = 1;

	public int GetDamage() {
		return DAMAGE;
	}

}
