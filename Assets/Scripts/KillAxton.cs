using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillAxton : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<CharacterController2D>() != null)
        {
           Destroy(collision.gameObject);
            SceneManager.LoadScene(0);
        }
    }

}
