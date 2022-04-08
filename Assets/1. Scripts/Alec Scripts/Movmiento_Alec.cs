using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movmiento_Alec : MonoBehaviour
{
    [Header("Vel y Salto")]
    public float Velocidad;
    public float FuerzaDeSalto;
    public bool CandoubleJump;
    public bool DoubleJump; 

    [Header("Ground")]
    [Space]
    public Transform groundcheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask WhatIsGround; 

    //Direcciones 
    private float Vertical;
    private float Horizontal;

    //Componentes
    private Rigidbody2D rg2D;
    private Animator Animator;

    public static Movmiento_Alec instance; 

    private void Awake()
    {
        if(instance == null)
        {
           instance = this; 
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    void Start()
    {
        CandoubleJump = true; 
        //Conozco los componentes 
        rg2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        //Si estoy en el piso, puedo saltar
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, WhatIsGround); 
        if(isGrounded)
        {
            Animator.SetBool("jump", false);
        }
        else
        {
            Animator.SetBool("jump", true); 
        }

        Volteo();
        Ataque();
        
        Salto();
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Salto()
    {
        //Puedo saltar
        if(Input.GetButtonDown("Jump") && isGrounded && CandoubleJump)
        {
            rg2D.velocity = new Vector2(rg2D.velocity.x, FuerzaDeSalto);
            DoubleJump = false; 
        }
        else if (Input.GetButtonDown("Jump") && CandoubleJump && !DoubleJump)
        {
            rg2D.velocity = new Vector2(rg2D.velocity.x, FuerzaDeSalto);
            DoubleJump = true; 
        }
    }
    public void Movimiento()
    {
        //Puedo correr
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = rg2D.velocity.y; 
        rg2D.velocity = new Vector2(Horizontal * Velocidad, Vertical);
        
        //Animacion de correr
        if(rg2D.velocity.x != 0.0f)
        {
            Animator.SetBool("running", true);
        }
        else
        {
            Animator.SetBool("running", false);
        }
    }
    public void Volteo()
    {
        //Me doy vuelta para mirar
        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-3.2124f, 3.6189f, 1f);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(3.2124f, 3.6189f, 1f);
        }
    }
    public void Ataque()
    {
        //Animacion de ataque
        if (Input.GetButtonDown("Fire1"))
        {
            Animator.SetBool("attack", true);
        }
        else
        {
            Animator.SetBool("attack", false);
        }
    }
}
