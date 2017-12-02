using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField]
    float SPEED = 2.0f;
    [SerializeField]
    float GROUNDFRICTION = 0.5f;
    [SerializeField]
    Rigidbody _rgbg;

    [HideInInspector]
    public bool _isDead = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    private void LateUpdate()
    {
        _rgbg.velocity *= GROUNDFRICTION;
    }

    private void move()
    {
        float xModifier = Input.GetAxis("Horizontal");
        float zModifier = Input.GetAxis("Vertical");
        _rgbg.velocity += new Vector3(xModifier * SPEED, 0, zModifier * SPEED);
    }
}
