using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace TMPro.Examples
{
    
    public class CountDown : MonoBehaviour
    {

        public string levelToLoad;
        private float timer = 10f;
        


        void Start()
        {
            
        }


        void Update()
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }

    }
}
