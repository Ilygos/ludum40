using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {


    [SerializeField]
    float FIRE_RATE = 1.0f;
    [SerializeField]
    GameObject BULLET_PREFAB;


    [HideInInspector]
    public float deadzone = 0.2f;
    Vector2 axis;
    Animator _anim;
    bool scheduledShot = false;
    bool prevFireInput = false;
    PlayerInput _input;
    float cooldown = 1.0f;


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


            Vector2 inputAxis = _input.aimAxis;

            if (inputAxis.magnitude > deadzone)
            {
                axis = inputAxis;
            }
            transform.rotation = Quaternion.Euler(90, Mathf.Atan2(axis.y, axis.x) * Mathf.Rad2Deg + 85f, 0);

        }

        if (!GetComponentInParent<CharacterController>()._isDead)
        {
            GameObject bullet;

            if (_input.fire > 0.2) // Todo: Inpractical in case you press a the wrong time you to have wait a whole fireFrame before firering. Also, don't count frame, count second.
            {
                // prevFireInput = true;
                scheduledShot = true;

                if (cooldown <= 0.0f && scheduledShot)
                {
                    bullet = Instantiate(BULLET_PREFAB, transform.position, Quaternion.identity);
                    bullet.GetComponent<Bullet>().initialize(transform.up, _input.playerIndex);
                    cooldown = FIRE_RATE;
                    scheduledShot = false;
                }
            }



        }

    }
}