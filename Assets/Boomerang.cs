using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {

    bool go;

    GameObject player;
    GameObject axe;

    Transform itemToRotate;
    Vector2 locationInfrontOfPlayer;


	// Use this for initialization
	void Start () {
        go = false;
        player = GameObject.Find("Axton Standing");
        axe = GameObject.Find("Axe(1)");

        axe.GetComponent<MeshRenderer>().enabled = false;

        itemToRotate = gameObject.transform.GetChild(0);

        locationInfrontOfPlayer = new Vector2(player.transform.position.x + 10, player.transform.position.y + 1);

        StartCoroutine(Boom());
	}
	
    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.5f);
        go = false;
    }


	// Update is called once per frame
	void Update () {
        itemToRotate.transform.Rotate(0,Time.deltaTime * 500, 0);

        if(go)
        {
            transform.position = Vector2.MoveTowards(transform.position,locationInfrontOfPlayer,Time.deltaTime * 40);
        }

        if(!go)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x,player.transform.position.y + 1), Time.deltaTime * 40);
        }

        if(!go && Vector2.Distance(player.transform.position, transform.position) < 1.5)
        {
            axe.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
	}
}
