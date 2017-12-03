using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public float deadzone = 0.2f;
    public float fireRate = 1.0f;
    public Transform anchorGun;
	public Aim aim;

    Vector2 axis;
    public GameObject bulletPrefab;
    Animator _anim;
    float cooldown = 1.0f;
    bool scheduledShot = false;
    bool prevFireInput = false;
    PlayerInput _input;


    // Use this for initialization
    void Start () {
        //_anim = transform.parent.gameObject.GetComponent<Animator>();
        _input = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (!GetComponentInParent<CharacterController>()._isDead)
        {
            GameObject bullet;

            if (_input.fire > 0.2) // Todo: Inpractical in case you press a the wrong time you to have wait a whole fireFrame before firering. Also, don't count frame, count second.
            {
                // prevFireInput = true;
                scheduledShot = true;

                if (cooldown <= 0.0f && scheduledShot)
                {
					Instantiate(bulletPrefab, anchorGun.position, aim.Rotation);
                    cooldown = fireRate;
                    scheduledShot = false;
                }
            }



        }

    }
}