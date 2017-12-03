using UnityEngine;

public class Shot : MonoBehaviour {

    public float fireRate = 1.0f;
    public Transform anchorGun;
	public Aim aim;

    [SerializeField]
    float FIRE_RATE = 1.0f;
    [SerializeField]
    GameObject BULLET_PREFAB;

    [HideInInspector]
    public float deadzone = 0.2f;
    Vector2 axis;
    bool scheduledShot = false;
    PlayerInput _input;
    float cooldown = 1.0f;


    // Use this for initialization
    void Start () {
        _input = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (!GetComponentInParent<CharacterController>()._isDead)
        {
            if (_input.fire > 0.2) // Todo: Inpractical in case you press a the wrong time you to have wait a whole fireFrame before firering. Also, don't count frame, count second.
            {
                // prevFireInput = true;
                scheduledShot = true;

                if (cooldown <= 0.0f && scheduledShot)
                {
					Instantiate(BULLET_PREFAB, anchorGun.position, aim.Rotation);
                    cooldown = FIRE_RATE;
                    scheduledShot = false;
                }
            }
        }

    }
}
