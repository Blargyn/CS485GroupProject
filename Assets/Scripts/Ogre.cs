using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ogre : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerController>() != null)
        {
           Destroy(collision.gameObject);
            SceneManager.LoadScene(0);
        }
    }

}
