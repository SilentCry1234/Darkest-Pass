using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_Enemigo : MonoBehaviour
{
    public GameObject projectile;
    public Transform Origen;

    public float TimeToShoot;
    public float Shootcooldown;

    public bool freqShooter;
    public bool wathcer; 

    void Start()
    {
        Shootcooldown = TimeToShoot; 
    }

    void Update()
    {
        if (freqShooter)
        {
            Shootcooldown -= Time.deltaTime;

            if (Shootcooldown < 0)
            {
                Shoot(); 
            }
        }

        if(wathcer)
        {

        }
    }


    public void Shoot()
    {
        GameObject Cross = Instantiate(projectile, Origen.position, Quaternion.identity);
        if (transform.localScale.x < 0)
        {
            Cross.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f), ForceMode2D.Force);
        }
        else
        {
            Cross.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f), ForceMode2D.Force);
        }
        Shootcooldown = TimeToShoot;
    }
}
