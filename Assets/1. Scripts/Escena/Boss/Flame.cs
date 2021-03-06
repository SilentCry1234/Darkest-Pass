using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    float moveSpeed;
    Rigidbody2D rb2d;
    Vector2 moveDirection;
    Movmiento_Alec target; 

    void Start()
    {
        moveSpeed  = GetComponent<Enemigo>().speed;
        rb2d       = GetComponent<Rigidbody2D>();
        target     = Movmiento_Alec.instance;

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y); 
    }

    void Update()
    {
        
    }
}
