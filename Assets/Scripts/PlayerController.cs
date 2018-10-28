using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public LayerMask ground;
    public Transform groundcheck;
    float velX;
    float velY;
    bool facingRight = true;
    Rigidbody2D rigBody;
    Animator anim;
    bool isRunning =  false;
    bool canJump = false;
    float minX;
    float maxX;
	// Use this for initialization
	void Start () {
        rigBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -bounds.x + .5f;
        maxX = bounds.x - .5f;
    }
	
	// Update is called once per frame
	void Update () {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigBody.velocity.y;
        rigBody.velocity = new Vector2(velX * moveSpeed, velY);
        canJump = Physics2D.OverlapCircle(groundcheck.position, 0.15f, ground);

        if (velX != 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        anim.SetBool("isRunning",isRunning);

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rigBody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }

        if (transform.position.x < minX)
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }

        if (transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }

    void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (velX > 0)
        {
            facingRight = true;
        }
        else if (velX < 0)
        {
            facingRight = false;
                }
        if(((facingRight) &&(localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }
}
