﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private SpriteRenderer sprite;    
    private float walkLeft;
    private float walkRight;
    public float walkSpeed = 1.0f;
    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX;


    void Start()
    {
        this.originalX = this.transform.position.x;
        walkLeft = transform.position.x - 3.0f;
        walkRight = transform.position.x + 3.0f;
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true;
    }

    
    void Update()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= walkRight)
        {
            walkingDirection = -1.0f;
            sprite.flipX = false;
        }
        else if (walkingDirection < 0.0f && transform.position.x <= walkLeft)
        {
            walkingDirection = 1.0f;
            sprite.flipX = true;
        }
        transform.Translate(walkAmount);
    }
}
