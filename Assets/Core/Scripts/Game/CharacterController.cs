using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField][Range(1,5)]
    float SPEED = 2.0f;
    [SerializeField][Range(0.5f,1)]
    float GROUNDFRICTION = 0.9f;
    [SerializeField][Range(16,32)]
    int DASH_AMPLITUDE = 24;
    [SerializeField]
    Rigidbody _rgbg;
    [HideInInspector]
    public PlayerInput input;
    private bool prevDashInput;
    [HideInInspector]
    public bool _isDead = false;
	private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
        input = GetComponent<PlayerInput>();
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    private void LateUpdate()
    {
        _rgbg.velocity *= GROUNDFRICTION;
		transform.SetY(initialPosition.y);
    }

    private void move()
    {
        Vector2 modifierMove = input.moveAxis;
        if (input.dash && !prevDashInput)
        {
            prevDashInput = true;
            modifierMove *= DASH_AMPLITUDE;
        }
        else if (!input.dash)
            prevDashInput = false;
        _rgbg.velocity += new Vector3(modifierMove.x * SPEED, 0, modifierMove.y * SPEED);
    }
}
