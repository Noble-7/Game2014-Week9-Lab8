﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Joystick joystick;
    public float joystickHorizontalSensitivity;
    public float horizontalForce;
    public float verticalForce;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        _Move();

    }




    void _Move()
    {
        if(joystick.Horizontal > joystickHorizontalSensitivity)
        {
            //right
            _rigidBody.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            _spriteRenderer.flipX = false;
            _animator.SetInteger("AnimState", 1);
        }
        else if (joystick.Horizontal < -joystickHorizontalSensitivity)
        {
            //left
            _rigidBody.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            _spriteRenderer.flipX = true;
            _animator.SetInteger("AnimState", 1);

        }
        else
        {
            //idle
            _animator.SetInteger("AnimState", 0);

        }

    }
}