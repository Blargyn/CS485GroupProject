using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private float flyUp;
    private float flyDown;
    public float flySpeed = 1.0f;
    float flyDirection = -1.0f;
    Vector2 flyAmount;
    float originalY;
    private bool Check = false;

    void Start ()
    {
        this.originalY = this.transform.position.y;
        flyUp = transform.position.y + 0.5f;
        flyDown = transform.position.y - 0.5f;
    }
	
	
	void Update ()
    {
        if (Check)
        {
            Destroy(gameObject);
        }
        flyAmount.y = flyDirection * flySpeed * Time.deltaTime;
        if (flyDirection > 0.0f && transform.position.y >= flyUp)
        {
            flyDirection = -1.0f;
        }
        else if (flyDirection < 0.0f && transform.position.y <= flyDown)
        {
            flyDirection = 1.0f;
        }
        transform.Translate(flyAmount);

    }

    public void Damage(int damage)
    {
        Check = true;
    }
}


