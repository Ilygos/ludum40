using UnityEngine;

public class CharacterController : MonoBehaviour {

	[SerializeField][Range(1, 5)]
	float SPEED = 2.0f;
	[SerializeField][Range(0.5f, 1)]
	float GROUNDFRICTION = 0.9f;
	[SerializeField][Range(16, 32)]
	int DASH_AMPLITUDE = 24;
	[SerializeField]
	Rigidbody rbody;
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
	public Aim aim;

	void Start() {
		input = GetComponent<PlayerInput>();
		_anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody>();
		initialPosition = transform.position;
	}

	void Update() {
		Move();
		ChangeSprite();
	}

	void ChangeSprite() {
		float aimRotation = aim.Rotation.eulerAngles.y;
		int eighthOf360 = (int)aimRotation / 45;

		foreach (string boolName in triggerNames)
			_anim.SetBool(boolName, false);

		_anim.SetBool(triggerNames[eighthOf360], true);
	}

	void LateUpdate() {
		rbody.velocity *= GROUNDFRICTION;
		transform.SetY(initialPosition.y);
	}

	void Move() {
		Vector2 moveAxes = input.moveAxis;

		if (input.dash && !prevDashInput) {
			prevDashInput = true;
			moveAxes *= DASH_AMPLITUDE;
		} else if (!input.dash)
			prevDashInput = false;

		rbody.velocity += new Vector3(moveAxes.x * SPEED, 0, moveAxes.y * SPEED);
	}
}
