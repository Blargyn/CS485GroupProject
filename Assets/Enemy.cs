using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    private bool Check = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Check)
        {
            Destroy(gameObject);
        }
	}


    public void Damage(int damage)
    {
        Check = true;
        //curHealth -= damage;
        //gameObject.GetComponent<Animation>().Play;
    }

}
