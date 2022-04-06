using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && transform.GetComponentInParent<Proyectil_Enemigo>().wathcer == true)
        {
            transform.GetComponentInParent<Proyectil_Enemigo>().Shoot();
        }
    }


}
