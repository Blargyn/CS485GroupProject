using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOgre : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.transform.GetComponent<PlayerController>() != null)
        {
            Destroy(target.gameObject);
        }
    }
}
