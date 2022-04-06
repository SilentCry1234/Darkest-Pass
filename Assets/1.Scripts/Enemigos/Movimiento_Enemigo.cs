using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Enemigo : MonoBehaviour
{
    [Header("Componentes")]
    [Space]
    float speed;
    Rigidbody2D rb;
    Animator anim;

    [Header("Formas de Moverse")]
    [Space]
    public bool isStatic;
    public bool isWalker;
    public bool isPatrol;
    public bool shouldWait;
    public bool LlegoalPunto; 
    public float timeToWait;
    bool isWaiting; 
    bool walksRight;

    [Header("Deteccion para no caerse")]
    [Space]
    public Transform wallCheck;
    public Transform pitCheck;
    public Transform GroundCheck;
    bool wallDetected;
    bool pitDetected;
    bool isGrounded;
    public float detectionRadius;
    public LayerMask WhatIsGround;

    [Header("Puntos-Patrol")]
    public Transform PuntoA, PuntoB;
    public bool goToA, goToB; 


    void Start()
    {
        goToA = true; 
        speed = GetComponent<Enemigo>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, WhatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, WhatIsGround);
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, detectionRadius, WhatIsGround);

        if ((pitDetected || wallDetected)  && isGrounded) 
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
       if(isStatic)
       {
          anim.SetBool("Idle", true);
           rb.constraints = RigidbodyConstraints2D.FreezeAll; 
       }
       if(isWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);
            if (!walksRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
       if(isPatrol)
        {
            if(goToA)
            {
                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y); 
                }
                if(Vector2.Distance(transform.position, PuntoA.position) < 1f)
                {
                    if(shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }
                }
            }

            if(goToB)
            {
                if(!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                }
                if (Vector2.Distance(PuntoB.position, transform.position) < 1f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }
                }
            }
        }
       if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(1, 1); 
        }
       else if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    IEnumerator Waiting()
    {
        if(!LlegoalPunto)
        {
            LlegoalPunto = true; 
            anim.SetBool("Idle", true);
            isWaiting = true;
            yield return new WaitForSeconds(timeToWait);
            anim.SetBool("Idle", false);
            if (goToA)
            {
                goToA = false;
                goToB = true;
            }
            else if (goToB)
            {
                goToA = true;
                goToB = false;
            }
            isWaiting = false;
            LlegoalPunto = false; 
        }
    }

    public void Flip()
    {
        walksRight = !walksRight;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }
}
