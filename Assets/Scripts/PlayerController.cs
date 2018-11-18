using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public float jumpForce = 600f;
    public LayerMask theGround;
    public Transform groundCheck;
    bool onTheGround = false;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

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
        anim.SetBool("isRunning", isRunning);

        onTheGround = Physics2D.Linecast(transform.position, groundCheck.position, theGround);
        anim.SetBool("onTheGround", onTheGround);

        if(rigBody.velocity.y < 0)
        {
            rigBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rigBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        if (onTheGround && Input.GetButtonDown("Jump"))
        {
            velY = 0f;
            rigBody.AddForce(new Vector2(0, jumpForce));
        }

        //if (Input.GetKeyDown(KeyCode.Space) && canJump)
        //{
        //    canJump = false;
        //    rigBody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        //}

        //if (transform.position.x < minX)
        //{
        //    Vector3 temp = transform.position;
        //    temp.x = minX;
        //    transform.position = temp;
        //}

        //if (transform.position.x > maxX)
        //{
        //    Vector3 temp = transform.position;
        //    temp.x = maxX;
        //    transform.position = temp;
        //}
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LevelHouse")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
