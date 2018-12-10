using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack2 : MonoBehaviour {
    public GameObject boomerang;
    public AudioClip audioSwing = null;
    private bool attacking = false;
    private bool throwing = false;
    private float attackTimer = 0f;
    private float attackCd = 0.3f;

    private float throwTimer = 0f;
    private float throwCd = 0.7f;

   // Boomerang1 boomerang1;

 //   GameObject axe;

    CharacterController2D direction;
    public Collider2D attackTrigger;
    private Animator anim;
    GameObject player;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
       // axe = GameObject.Find("BoomerangTest 1");
    }
    private void Start()
    {
        player = GameObject.Find("Axton standing");
        direction = player.GetComponent<CharacterController2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown("f") && !attacking)
        {
            this.GetComponent<AudioSource>().PlayOneShot(audioSwing);
            attacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;

        }
        if (Input.GetKeyDown(KeyCode.Q) && !throwing)
        {
            throwing = true;
            throwTimer = throwCd;
            GameObject clone;
           // boomerang1.attackTrigger.enabled = true;
            //clone = Instantiate(boomerang, new Vector2(transform.position.x + 13, transform.position.y + 3), transform.rotation) as GameObject;
            if (direction.m_FacingRight)
                clone = Instantiate(boomerang, new Vector2(transform.position.x + 13, transform.position.y + 3), transform.rotation) as GameObject;
            else if (!direction.m_FacingRight)
                clone = Instantiate(boomerang, new Vector2(transform.position.x + 10.5f, transform.position.y + 3), transform.rotation) as GameObject;
        }
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        else if (throwing)
        {

            if (throwTimer > 0)
            {
                throwTimer -= Time.deltaTime;
            }
            else
            {
                throwing = false;
                attackTrigger.enabled = false;
            }
        }
        anim.SetBool("Throwing", throwing);
        anim.SetBool("Attacking", attacking);
    }
}
