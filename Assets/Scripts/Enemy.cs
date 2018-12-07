using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float walkLeft;
    private float walkRight;
    public float walkSpeed = 1.0f;
    public AudioClip audioHit = null;
    float walkingDirection = -1.0f;
    Vector2 walkAmount;
    float originalX;
    private bool Check = false;
	
	void Start ()
    {
        this.originalX = this.transform.position.x;
        walkLeft = transform.position.x - 3.0f;
        walkRight = transform.position.x + 3.0f;
     }
	
	
	void Update ()
    {
		if(Check)
        {
            this.GetComponent<AudioSource>().PlayOneShot(audioHit);
            Destroy(gameObject);
        }
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= walkRight)
        {
            walkingDirection = -1.0f;
            transform.localScale = new Vector3(1,1,1);
        }
        else if (walkingDirection < 0.0f && transform.position.x <= walkLeft)
        {
            walkingDirection = 1.0f;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.Translate(walkAmount);
    }


    public void Damage(int damage)
    {
        Check = true;
    }
}
