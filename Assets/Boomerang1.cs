using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang1 : MonoBehaviour
{
    private Animator anim;
    private bool attacking = false;
    bool go;
    CharacterController2D direction;
    GameObject player;
    GameObject axe;

    public Collider2D attackTrigger;

    Transform itemToRotate;
    Vector2 locationInfrontOfPlayer;
    Vector2 playerPosition;

    // Use this for initialization

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();      
        go = false;
        player = GameObject.Find("Axton standing");
        axe = GameObject.Find("Axe");
        direction = player.GetComponent<CharacterController2D>();
        //itemToRotate = gameObject.transform.GetChild(0);
        axe.GetComponent<SpriteRenderer>().enabled = false;
       // attackTrigger.enabled = true;


        itemToRotate = gameObject.transform.GetChild(0);
        if(direction.m_FacingRight)
        locationInfrontOfPlayer = new Vector2(player.transform.position.x + 15, player.transform.position.y + 3);
        else if (!direction.m_FacingRight)
            locationInfrontOfPlayer = new Vector2(player.transform.position.x + 7, player.transform.position.y + 3);
        //locationInfrontOfPlayer = new Vector3(player.transform.position.x,player.transform.position.y + 1, player.transform.position.z) + player.transform.forward * 10f;

        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(0.3f);
        go = false;
    }


    // Update is called once per frame
    void Update()
    {
        //itemToRotate.GetComponent<SpriteRenderer>().enabled = true;
        itemToRotate.transform.Rotate(0, Time.deltaTime * 200, 15);
        
        if (go)
        {
            // playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
            //transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
         //   attacking = true;
            transform.position = Vector2.MoveTowards(transform.position, locationInfrontOfPlayer, Time.deltaTime * 20);
            //float x = transform.position.x;
            //float y = transform.position.y;
            //float z = transform.position.z;
            //transform.position = Vector3.MoveTowards(transform.position,locationInfrontOfPlayer,Time.deltaTime * 40);
        }

        if (!go)
        {
          //  attacking = true;
            // transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - 20, player.transform.position.y + 5), Time.deltaTime * 40);
            if (direction.m_FacingRight)
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x - 20, player.transform.position.y + 5), Time.deltaTime * 20);
            else if (!direction.m_FacingRight)
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x + 20, player.transform.position.y + 3), Time.deltaTime * 20);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 40);
        }
       // anim.SetBool("Attacking", attacking);
        if (!go && Vector2.Distance(new Vector2(player.transform.position.x + 13, player.transform.position.y + 3), transform.position) < 0.2)
      // if(!go && Vector3.Distance(player.transform.position,transform.position) < 1.5)
        {
           // axe.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
