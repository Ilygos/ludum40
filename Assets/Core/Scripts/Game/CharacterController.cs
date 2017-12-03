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
    public string[] triggerNames;
    [HideInInspector]
    public float deadzone = 0.2f;
    [HideInInspector]
    public PlayerInput input;
    bool prevDashInput;
    Animator _anim;
    [HideInInspector]
    public bool _isDead = false;
	Vector3 initialPosition;
    Vector2 axis;

    // Use this for initialization
    void Start () {
        input = GetComponent<PlayerInput>();
        _anim = GetComponent<Animator>();
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        move();
        changeSprite();

    }

    void changeSprite()
    {
        Vector2 inputAxis = input.aimAxis;
        if (inputAxis.magnitude > deadzone)
        {
            axis = inputAxis;
        }

		Debug.Log("inputAxis: " + inputAxis);
		Debug.Log("axis: " + axis);

        int angle = (int)(Mathf.Atan2(axis.y, axis.x) * Mathf.Rad2Deg) + 180;
        int eighthOf360 = angle / 45;

        foreach (string boolName in triggerNames)
            _anim.SetBool(boolName, false);

        _anim.SetBool(triggerNames[eighthOf360], true);

    }

    void LateUpdate()
    {
        _rgbg.velocity *= GROUNDFRICTION;
		transform.SetY(initialPosition.y);
    }

    void move()
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
