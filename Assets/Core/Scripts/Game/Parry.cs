using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            if (GetComponentInParent<CharacterController>().input.parry)
            {
                other.GetComponent<Rigidbody>().velocity *= -2;
                other.GetComponent<Bullet>().bouncingLeft = 0;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
