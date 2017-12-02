﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public float deadzone = 0.2f;
    public float fireRate = 1.0f;
    public Transform anchorGun;

    private Vector2 axis;
    public GameObject bulletPrefab;
    private Animator _anim;
    private float cooldown = 1.0f;
    private bool scheduledShot = false;
    private bool prevFireInput = false;
    private PlayerInput _input;


    // Use this for initialization
    void Start () {
        //_anim = transform.parent.gameObject.GetComponent<Animator>();
        _input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (!GetComponent<CharacterController>()._isDead)
        {


            Vector2 inputAxis = _input.aimAxis;

            if (inputAxis.magnitude > deadzone)
            {
                axis = inputAxis;
            }
            transform.rotation = Quaternion.Euler(90, Mathf.Atan2(axis.y, axis.x) * Mathf.Rad2Deg + 64, 0);

        }

        if (!GetComponent<CharacterController>()._isDead)
        {
            GameObject bullet;

            if (_input.fire > 0.2) // Todo: Inpractical in case you press a the wrong time you to have wait a whole fireFrame before firering. Also, don't count frame, count second.
            {
                // prevFireInput = true;
                scheduledShot = true;

                if (cooldown <= 0.0f && scheduledShot)
                {
                    bullet = Instantiate(bulletPrefab, anchorGun.position, Quaternion.identity);
                    bullet.GetComponent<Bullet>().initialize(anchorGun.up, _input.playerIndex);
                    cooldown = fireRate;
                    scheduledShot = false;
                }
            }



        }

    }
}